using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTools : MonoBehaviour
{
	public static float V3ToAngle(Vector3 startPoint, Vector3 endPoint)
	{
		// Get Angle in Radians
		float rad = Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x);
		
		// Get Angle in Degrees
		float deg = (180 / Mathf.PI) * rad;

		return deg;
	}

	public static float LineToAngle(Line line)
	{
		return V3ToAngle(line.start, line.end);
	}

	public static Vector3 RotatePoint(Vector3 Center, float angle, Vector3 pointIN)
	{
		//Convert angle degrees to radians
		float radians = Mathf.Deg2Rad * angle;

		pointIN.x -= Center.x;
		pointIN.y -= Center.y;

		float xnew = pointIN.x * Mathf.Cos(radians) - pointIN.y * Mathf.Sin(radians);
		float ynew = pointIN.x * Mathf.Sin(radians) + pointIN.y * Mathf.Cos(radians);

		return new Vector3(xnew + Center.x, ynew + Center.y);
	}

	public static float ToDegrees(float radian)
	{
		return Mathf.Rad2Deg * radian;
	}

	public static float ToRadians(float degree)
	{
		return Mathf.Deg2Rad * degree;
	}

	public static Vector3 CircleRadiusPoint(Vector3 Center, float angle, float radius)
	{
		//this method finds a point on a circle given a radius and angle. 
		//This will place the point relative to the origin Vector 3.
		//You will need to convert the given angle into a radian.

		//Used to draw object from top of screen
		angle += 90;

		return new Vector3(Center.x + (radius * Mathf.Cos(ToRadians(angle))), 
						   Center.y + (radius * Mathf.Sin(ToRadians(angle))));
	}

	public static void DrawCircle(Vector3 Center, float Radius, int Sides, Color color, Grid2D grid = null) 
	{
		if (Sides < 3) Sides = 3;

		float vertexAngle = 360 / Sides;

		List<Vector3> vertices = new List<Vector3>();

		//Get all verticies
		for (int i = 0; i < Sides; i++)
			vertices.Add(CircleRadiusPoint(Center, vertexAngle * i, Radius));

		for (int i = 0; i < vertices.Count; i++)
		{
			if (i + 1 != vertices.Count)
				new Line(vertices[i], vertices[i + 1], color).Draw(grid);
			else
				new Line(vertices[i], vertices[0], color).Draw(grid);
		}
	}

	public static Vector3 EllipseRadiusPoint(Vector3 Center, float angle, Vector3 Axis)
	{
		//Like CircleRadiusPoint, but scaling using the Axis Vector2 instead of the radius.

		return new Vector3(Center.x + (Axis.x * Mathf.Sin(ToRadians(angle))), 
						   Center.y + (Axis.y * Mathf.Cos(ToRadians(angle))));
	}

	public static void DrawEllipse(Vector3 Center, Vector2 Axis, int Sides, Color color, Grid2D grid = null)
	{
		if (Sides < 3) Sides = 3;

		float vertexAngle = 360 / Sides;

		List<Vector3> vertices = new List<Vector3>();

		//Get all verticies
		for (int i = 0; i < Sides; i++)
			vertices.Add(EllipseRadiusPoint(Center, vertexAngle * i, Axis));

		for (int i = 0; i < vertices.Count; i++)
		{
			if (i + 1 != vertices.Count)
				new Line(vertices[i], vertices[i + 1], color).Draw(grid);
			else
				new Line(vertices[i], vertices[0], color).Draw(grid);
		}
	}
}
