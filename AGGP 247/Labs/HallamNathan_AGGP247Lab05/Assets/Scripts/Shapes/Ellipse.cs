using Drawing.Glint;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : DrawingObject
{
	public Vector3 Position = Vector2.zero;
	public Vector3 Axis = Vector2.one;
	public int Sides = 32;
	public float Width = 2.0f;
	public Color color = Color.white;

	public Ellipse() : base()
	{

	}

	public override void Draw(Grid2D grid = null)
	{
		if (Sides < 3) Sides = 3;

		float sides = Sides;
		float vertexAngle = 360 / sides;

		if (vertices.Count == 0)
			//Get all verticies
			for (int i = 0; i < Sides; i++)
				vertices.Add(DrawingTools.EllipseRadiusPoint(Center, vertexAngle * i, Axis));


		if (Lines.Count == 0)
			for (int i = 0; i < vertices.Count; i++)
			{
				if (i + 1 != vertices.Count)
					Lines.Add(new Line(vertices[i], vertices[i + 1], color));
				else
					Lines.Add(new Line(vertices[i], vertices[0], color));
			}

		base.Draw(grid);
	}
}
