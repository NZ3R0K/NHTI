using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;
using TMPro;

public class Game : MonoBehaviour
{
	public Grid2D grid;

	public World world;

	public Shuttle shuttle;

	public TMP_Text movementText;
	public TMP_Text stfText;
	public TMP_Text infoText;

	public float score;
	[HideInInspector] public float time;

	public bool waitForInput = true;

	// Start is called before the first frame update
	void Start()
	{
		grid.screenSize = new Vector3(Screen.width, Screen.height);

		infoText.text = "[SPACE] Start Game \n [ESC] Exit Application";
	}



	// Update is called once per frame
	void Update()
	{
		if (waitForInput) return;

		grid.gridSize = (world.zoom) ? world.zoomedInSize : world.zoomedOutSize;

		shuttle.Draw(this, world, grid);
		shuttle.Physics(world);
		shuttle.Move();

		int groundPolyIndex = (int)(((shuttle.Position.x - (-160)) * 160) / (160 - (-160)));

		int shuttleGroundPolyIndex;

		if (groundPolyIndex < 0) shuttleGroundPolyIndex = 0;
		else if (groundPolyIndex > world.groundPolygons.Count - 1) shuttleGroundPolyIndex = world.groundPolygons.Count - 1;
		else shuttleGroundPolyIndex = groundPolyIndex;

		if (world.groundPolygons.Count <= 3) return;
		float groundAveratgeHeight = (world.groundPolygons[shuttleGroundPolyIndex].Verticies[0].y + world.groundPolygons[shuttleGroundPolyIndex].Verticies[1].y) / 2;
		int shuttleAltitude = (int)((-(groundAveratgeHeight - shuttle.Position.y) - 2) * 5 - 2);


		int seconds = Math.Round(time);
		int minutes = 0;

		if (!shuttle.isStatic)
		{
			time += Time.deltaTime;

			if (shuttle.Fuel <= shuttle.FuelStart / 4)
			{


				if (seconds % 2 == 0) infoText.enabled = true;
				else
				{
					infoText.enabled = false;
					if (shuttle.Fuel > 0) infoText.text = "Low on Fuel";
					else infoText.text = "FUEL DEPLETED";
				}
			}
		}
			
		if (seconds >= 60)
		{
			minutes++;
			seconds -= 60;
		}

		movementText.text =
			  $"Altitude\t\t {shuttleAltitude.ToString("0000")}"
			+ $"\nHorizontal Speed\t {((int)(shuttle.Velocity.x * 20)).ToString("0000")}" 
			+ $"\nVertical Speed\t {((int)(-shuttle.Velocity.y * 20)).ToString("0000")}";


		stfText.text =
		  $"Score\t  {score.ToString("0000")}"
		+ $"\nTime\t  {minutes}:{seconds.ToString("00")}"
		+ $"\nFuel\t  {Math.Round(shuttle.Fuel).ToString("0000")}";

		world.DrawTerrain(grid);
	}

	public void BeginGame()
	{
		world.GenerateTerrain(grid);

		shuttle.Position = new Vector3(-100, 30);
		shuttle.Rotation = new Vector3(0, 0, 90);	

		shuttle.AddForce(-shuttle.up * 250);
	}

	public void Restart()
	{
		shuttle.Fuel = shuttle.FuelStart;
		score = 0;
		time = 0;

		BeginGame();

		shuttle.isStatic = false;
	}
}
