using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cannon
{
	public MTransform Transform;

	public float Power;

	public float MaxPower;

	public float PowerMultiplier;

	public float RotationSpeed;

	public float MaxRotation = 72;

	public float ballMass = 10;

	[Tooltip("Points must go in a clockwise fashion for collision detection to work")]
	public List<Vector3> Verticies = new List<Vector3>();

	public Color EdgeColor;
	public Color FillColor;
	[HideInInspector] public List<Vector3> fillPixels = new List<Vector3>();
	[HideInInspector] public List<Line> fillLines = new List<Line>();
	[HideInInspector] public List<Vector3> OldVerticies = new List<Vector3>();
	[HideInInspector] public Vector3 OldPosition = Vector2.zero;
	[HideInInspector] public bool update = true;

	public void DrawLine(Line line, Grid2D grid = null, bool gridSpace = false)
	{
		if (gridSpace)
		{
			line.start = grid.GridToScreen(line.start);
			line.end = grid.GridToScreen(line.end);
		}

		Glint.AddCommand(line);
	}

	public void DrawCannon(Grid2D grid)
	{
		for (int i = 0; i < Verticies.Count; i++)
		{
			if (i == Verticies.Count - 1)
				DrawLine(new Line(Verticies[i] + Transform.Position, Verticies[0] + Transform.Position, EdgeColor), grid, true);
			else
				DrawLine(new Line(Verticies[i] + Transform.Position, Verticies[i + 1] + Transform.Position, EdgeColor), grid, true);
		}
	}

	public void ChangePower(float value)
	{
		Power += value;

		if (Power > MaxPower) Power = MaxPower;
		if (Power < 0) Power = 0;
	}

	public void Rotate(float angle)
	{
		if (Transform.Rotation.z > MaxRotation && angle > 0) return;
		if (Transform.Rotation.z < -MaxRotation && angle < 0) return;

		angle *= RotationSpeed;

		//Convert angle degrees to radians
		float radians = Mathf.Deg2Rad * angle;

		for (int i = 0; i < Verticies.Count; i++)
		{
			Vector3 point = Verticies[i];

			float xnew = point.x * Mathf.Cos(radians) - point.y * Mathf.Sin(radians);
			float ynew = point.x * Mathf.Sin(radians) + point.y * Mathf.Cos(radians);

			Verticies[i] = new Vector3(xnew, ynew);
		}

		Transform.Rotation.z += angle;
	}

	public void Shoot()
	{
		Balls ball = new Balls(Transform.Position, Transform.Rotation);
		ball.rb.Mass = ballMass;

		Vector3 ballForce = Transform.up * Power * PowerMultiplier;

		ball.rb.AddForce(ballForce);

		Lab05Part2.instance.balls.Add(ball);
		Lab05Part2.instance.PhysObjects.Add(ball);
	}
}
