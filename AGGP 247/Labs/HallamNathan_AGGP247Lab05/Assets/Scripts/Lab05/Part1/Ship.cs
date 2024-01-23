using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship
{
	public MTransform transform;
	public MRigidbody rb;

	[Tooltip("READONLY: Input values for the ship. X is Roation, Y is Thrust")]
	public Vector3 InputVelocity;

	public float Thrust;

	public float MaxSpeed;

	[Tooltip("In Degrees: How fast the ship rotates")]
	public float RotationSpeed;

	[Tooltip("Points must go in a clockwise fashion for collision detection to work")]
	public List<Vector3> Verticies = new List<Vector3>();

	public Color EdgeColor;
	public Color FillColor;
	[HideInInspector] public List<Vector3> fillPixels = new List<Vector3>();
	[HideInInspector] public List<Line> fillLines = new List<Line>();
	[HideInInspector] public List<Vector3> OldVerticies = new List<Vector3>();
	[HideInInspector] public Vector3 OldPosition = Vector2.zero;
	[HideInInspector] public bool update = true;

	public void Update()
	{
		MoveShip(InputVelocity.y * Thrust);
		RotateShip(InputVelocity.x * RotationSpeed);
	}

	#region Drawing
	public void DrawLine(Line line, Grid2D grid = null, bool gridSpace = false)
	{
		if (gridSpace)
		{
			line.start = grid.GridToScreen(line.start);
			line.end = grid.GridToScreen(line.end);
		}

		Glint.AddCommand(line);
	}

	public void DrawShip(Grid2D grid)
	{
		for (int i = 0; i < Verticies.Count; i++)
		{
			if (i == Verticies.Count - 1)
				DrawLine(new Line(Verticies[i] + transform.Position, Verticies[0] + transform.Position, EdgeColor), grid, true);
			else
				DrawLine(new Line(Verticies[i] + transform.Position, Verticies[i + 1] + transform.Position, EdgeColor), grid, true);
		}
	}
	#endregion Drawing

	#region Movement
	public void MoveShip(float thrust)
	{
		transform.Position += rb.Velocity;

		if (rb.Speed < MaxSpeed)
		{
			rb.Velocity += ((thrust / rb.Mass) * Time.deltaTime) * transform.up;
		}
		else if (rb.Speed > MaxSpeed) rb.Velocity = Vector3.MoveTowards(rb.Velocity, Vector3.zero, rb.Speed / 25);


		rb.Speed = rb.Velocity.magnitude;
	}

	public void RotateShip(float angle)
	{
		angle /= 90;

		//Convert angle degrees to radians
		float radians = Mathf.Deg2Rad * angle;

		for (int i = 0; i < Verticies.Count; i++)
		{
			Vector3 point = Verticies[i];

			float xnew = point.x * Mathf.Cos(radians) - point.y * Mathf.Sin(radians);
			float ynew = point.x * Mathf.Sin(radians) + point.y * Mathf.Cos(radians);

			Verticies[i] = new Vector3(xnew, ynew);
		}

		transform.Rotation.z += angle;
	}
	#endregion Movement

	public void DetectCollision(Vector3 thePoint, Grid2D grid)
	{
		#region Inside Triangle Guard Clause
		if (!Helper.isInsideTriangle(
			thePoint,
			Verticies[0] + transform.Position,
			Verticies[1] + transform.Position,
			Verticies[2] + transform.Position)
			) return;
		#endregion Inside Triangle Guard Clause

		#region Refresh Pixel List
		if (transform.Position != OldPosition)
		{
			OldPosition = transform.Position;
			update = true;
		}
		if (Verticies != OldVerticies)
		{
			OldVerticies = Verticies;
			update = true;
		}

		if (update)
		{
			fillPixels.Clear();

			for (int h = 0; h < Screen.height; h++)
			{
				for (int w = 0; w < Screen.width; w++)
				{
					Vector3 pixel = new Vector3(w, h);

					if (Helper.isInsideTriangle(pixel, Verticies[0] + transform.Position, Verticies[1] + transform.Position, Verticies[2] + transform.Position))
						fillPixels.Add(pixel);
				}
			}

			Vector3 start = Vector3.zero;
			Vector3 end = Vector3.zero;

			fillLines.Clear();

			// Go through list of pixels
			for (int i = 0; i < fillPixels.Count; i++)
			{
				if (i == 0) start = fillPixels[0];

				if (i == fillPixels.Count - 1 || fillPixels[i].y != fillPixels[i + 1].y)
				{
					end = fillPixels[i];
					fillLines.Add(new Line(start, end, FillColor));
					if (i < fillPixels.Count - 1)
						start = fillPixels[i + 1];
				}
			}

			update = false;
		}
		#endregion Refresh Pixel List

		#region Draw Triangle Filled
		foreach (Line line in fillLines)
			DrawLine(line, grid, true);
		#endregion Draw Triangle Filled
	}

	public void ScreenWrap(Vector3 horizontalOffset, Vector3 verticalOffset, float horizontalEdge, float verticalEdge, Grid2D grid)
	{
		if (transform.Position.x > horizontalEdge)
		{
			transform.Position -= horizontalOffset * 16;
		}
		else if (transform.Position.x < -horizontalEdge)
		{
			transform.Position += horizontalOffset * 16;
		}
		if (transform.Position.y > verticalEdge)
		{
			transform.Position -= verticalOffset * 16;
		}
		else if (transform.Position.y < -verticalEdge)
		{
			transform.Position += verticalOffset * 16;
		}
	}
}
