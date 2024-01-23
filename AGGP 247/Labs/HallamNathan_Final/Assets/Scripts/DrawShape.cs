using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrawShape
{
	/// <summary>
	/// Draw a Rectangle on a grid.
	/// </summary>
	/// <param name="Center">Center of the rectangle in gridspace.</param>
	/// <param name="Width">Width of the rectangle in gridspace.</param>
	/// <param name="Height">Height of the rectangle in gridspace.</param>
	/// <param name="Rotation">Rotation to draw the rectangle at in degrees.</param>
	/// <param name="LineColor">Color to draw the rectangle in.</param>
	/// <param name="Grid">Grid that the rectangle will be drawn on.</param>
	public static void Rectangle(Vector3 Center, float Width, float Height, float Rotation, Color LineColor, Grid2D Grid)
	{
		float halfWidth = Width / 2;
		float halfHeight = Height / 2;

		Line top = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y + halfHeight)), //TopLeft
							DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y + halfHeight)), //TopRight
							LineColor);

		Line right = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y + halfHeight)), //TopRight
							  DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y - halfHeight)), //BottomRight
							  LineColor);

		Line bottom = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y - halfHeight)), //BottomRight
							   DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y - halfHeight)), //BottomLeft
							   LineColor);

		Line left = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y - halfHeight)), //BottomLeft
							 DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y + halfHeight)), //TopLeft
							 LineColor);

		Grid.DrawLine(top);
		Grid.DrawLine(right);
		Grid.DrawLine(bottom);
		Grid.DrawLine(left);
	}

	/// <summary>
	/// Draw a Circle on a grid.
	/// </summary>
	/// <param name="Center">Center of the circle in gridspace.</param>
	/// <param name="Radius">Radius of the circle.</param>
	/// <param name="Sides">How many sides to draw to make the circle.</param>
	/// <param name="Rotation">Rotation to draw the circle at in degrees.</param>
	/// <param name="LineColor">Color to draw the circle in.</param>
	/// <param name="Grid">Grid that the circle will be drawn on.</param>
	public static void Circle(Vector3 Center, float Radius, int Sides, float Rotation, Color LineColor, Grid2D Grid)
	{
		Ellipse(Center, new Vector3(Radius, Radius), Sides, Rotation, LineColor, Grid);
	}

	/// <summary>
	/// Draw an Ellipse on a grid.
	/// </summary>
	/// <param name="Center">Center of the ellipse in gridspace.</param>
	/// <param name="Axis">Major and Minor axis of the ellipse.</param>
	/// <param name="Sides">How many sides to draw to make the ellipse.</param>
	/// <param name="Rotation">Rotation to draw the ellipse at in degrees.</param>
	/// <param name="LineColor">Color to draw the ellipse in.</param>
	/// <param name="Grid">Grid that the ellipse will be drawn on.</param>
	public static void Ellipse(Vector3 Center, Vector3 Axis, int Sides, float Rotation, Color LineColor, Grid2D Grid)
	{
		if (Sides < 3) Sides = 3;

		float vertexAngle = 360f / Sides;

		List<Vector3> vertices = new List<Vector3>();

		//Get all verticies
		for (int i = 0; i < Sides; i++)
			vertices.Add(DrawingTools.RotatePoint(Center, Rotation, DrawingTools.EllipseRadiusPoint(Center, vertexAngle * i, Axis)));

		for (int i = 0; i < vertices.Count; i++)
		{
			if (i + 1 != vertices.Count)
				Grid.DrawLine(new Line(vertices[i], vertices[i + 1], LineColor));
			else
				Grid.DrawLine(new Line(vertices[i], vertices[0], LineColor));
		}
	}

	/// <summary>
	/// Draw a Triangle on a grid.
	/// </summary>
	/// <param name="Center">Center of the triangle in gridspace.</param>
	/// <param name="Width">Width of the triangle in gridspace.</param>
	/// <param name="Height">Height of the triangle in gridspace.</param>
	/// <param name="Rotation">Rotation to draw the triangle at in degrees.</param>
	/// <param name="LineColor">Color to draw the triangle in.</param>
	/// <param name="Grid">Grid that the triangle will be drawn on.</param>
	public static void Triangle(Vector3 Center, float Width, float Height, float Rotation, Color LineColor, Grid2D Grid)
	{
		float halfWidth = Width / 2;
		float thirdHeight = Height / 3;

		Line top = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x, Center.y + 2 * thirdHeight)), //Top
							DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y - thirdHeight)), //BottomRight
							LineColor);

		Line bottomRight = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x + halfWidth, Center.y - thirdHeight)), //BottomRight
									DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y - thirdHeight)), //BottomLeft
									LineColor);

		Line bottomLeft = new Line(DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x - halfWidth, Center.y - thirdHeight)), //BottomRight
								   DrawingTools.RotatePoint(Center, Rotation, new Vector3(Center.x, Center.y + 2 * thirdHeight)), //Top
								   LineColor);

		Grid.DrawLine(top);
		Grid.DrawLine(bottomRight);
		Grid.DrawLine(bottomLeft);
	}
}
