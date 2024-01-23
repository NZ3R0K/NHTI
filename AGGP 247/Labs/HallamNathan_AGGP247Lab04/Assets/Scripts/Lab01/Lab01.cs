using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lab01 : MonoBehaviour
{
	public class Grid2D
	{
		public Vector3 screenSize;
		public Vector3 origin;

		public float gridSize = 10; //Was private
		public float minGridSize = 2f;  //Was private
		public float originSize = 20f;

		public int divisionCount = 5;      //Was private
		public int minDivisionCount = 2;   //Was private
	}

	public Color axisColor = Color.white;
	public Color lineColor = Color.gray;
	public Color divisionColor = Color.yellow;
	public Color originColor = Color.green;

	public bool isDrawingOrigin = false;
	public bool isDrawingAxis = true;
	public bool isDrawingDivisions = true;

	Grid2D grid = new Grid2D();

	public Grid2D getGrid
	{
		get { return grid; }
	}

	private void Start()
	{
		grid.origin = new Vector3(Screen.width / 2, Screen.height / 2);
	}

	void Update()
	{
		#region Draw Origin
		if (isDrawingOrigin)
		{
			DrawOrigin();
		}
		#endregion Draw Origin

		int divisionStepCount = 0;

		#region Vertical Lines
		for (float i = (grid.origin.x % grid.gridSize); i < Screen.width; i += grid.gridSize)
		{
			if (isDrawingAxis && i == grid.origin.x)
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), axisColor));

				divisionStepCount++;
			}
			else if (isDrawingDivisions && (grid.origin.x % (grid.divisionCount * grid.gridSize)) + (divisionStepCount * (grid.divisionCount * grid.gridSize)) == i)
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), divisionColor));

				divisionStepCount++;
			}
			else
			{
				DrawLine(new Line(new Vector3(i, 0), new Vector3(i, Screen.width), lineColor));
			}
		}
		#endregion Vertical Lines

		divisionStepCount = 0;

		#region Horizontal Lines
		for (float i = (grid.origin.y % grid.gridSize); i < Screen.width; i += grid.gridSize)
		{
			if (isDrawingAxis && i == grid.origin.y)
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), axisColor));

				divisionStepCount++;
			}
			else if (isDrawingDivisions && (grid.origin.y % (grid.divisionCount * grid.gridSize)) + (divisionStepCount * (grid.divisionCount * grid.gridSize)) == i)
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), divisionColor));

				divisionStepCount++;
			}
			else
			{
				DrawLine(new Line(new Vector3(0, i), new Vector3(Screen.width, i), lineColor));
			}
		}
		#endregion Horizontal Lines
	}

	//Takes the potential grid space and outputs it into screen space
	public Vector3 GridToScreen(Vector3 gridSpace)
	{
		//Add the gridSpace multiplied by its size to the center of the screen
		return new Vector3((Screen.width / 2) + (gridSpace.x * grid.gridSize), (Screen.height / 2) + (gridSpace.y * grid.gridSize));
	}

	//Takes in screen space and outputs it as grid space
	public Vector3 ScreenToGrid(Vector3 screenSpace)
	{
		//Subtract center screen from the given point and divide the value by the grids size
		return new Vector3((screenSpace.x - (Screen.width / 2)) / grid.gridSize, (screenSpace.y - (Screen.height / 2)) / grid.gridSize);
	}

	//Draws the given line
	public void DrawLine(Line line)
	{
		Glint.AddCommand(line);
	}

	//Draws the Origin Point (or Symbol)
	public void DrawOrigin()
	{
		#region Top to Left
		DrawLine(new Line
			(
			new Vector3(grid.origin.x, grid.origin.y + grid.originSize, 0),
			new Vector3(grid.origin.x + grid.originSize, grid.origin.y, 0),
			originColor)
			);


		#endregion Top to Left
		
		#region Left to Bottom
		DrawLine(new Line
			(
			new Vector3(grid.origin.x + grid.originSize, grid.origin.y),
			new Vector3(grid.origin.x, grid.origin.y - grid.originSize),
			originColor
			)) ;
		#endregion Left to Bottom

		#region Bottom to Right
		DrawLine(new Line
			(
			new Vector3(grid.origin.x, grid.origin.y - grid.originSize),
			new Vector3(grid.origin.x - grid.originSize, grid.origin.y),
			originColor
			));
		#endregion Bottom to Right

		#region Right to Top
		DrawLine(new Line
			(
			new Vector3(grid.origin.x - grid.originSize, grid.origin.y),
			new Vector3(grid.origin.x, grid.origin.y + grid.originSize),
			originColor
			));
		#endregion Right to Top
	}
}