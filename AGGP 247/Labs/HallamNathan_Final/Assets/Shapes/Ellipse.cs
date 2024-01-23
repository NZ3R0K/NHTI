using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse : DrawingObject
{
	public int Sides = 32;
	protected List<Vector3> Verticies = new List<Vector3>();
	protected int _oldSides;
	protected List<Vector3> _oldVerticies = new List<Vector3>();

	public override void Update()
	{
		base.Update();
	}

	protected override void UpdateShape()
	{
		if (Sides < 3) Sides = 3;
		if (Sides > 64) Sides = 64;

		float vertexAngle = 360f / Sides;

		Verticies.Clear();
		Lines.Clear();

		//Get all verticies
		for (int i = 0; i < Sides; i++)
			Verticies.Add(DrawingTools.RotatePoint(Position, Rotation.z, DrawingTools.EllipseRadiusPoint(Position, vertexAngle * i, Scale)));

		_updateShape = false;
	}

	public override void Draw(Grid2D grid = null)
	{
		if (_oldSides != Sides)
		{
			_oldSides = Sides;
			_updateShape = true;
		}
				
		if (_updateShape) UpdateShape();

		if (Lines.Count == 0)
			for (int i = 0; i < Verticies.Count; i++)
			{
				if (i + 1 != Verticies.Count)
					Lines.Add(new Line(Verticies[i], Verticies[i + 1], LineColor));
				else
					Lines.Add(new Line(Verticies[i], Verticies[0], LineColor));
			}

		base.Draw(grid);
	}
}
