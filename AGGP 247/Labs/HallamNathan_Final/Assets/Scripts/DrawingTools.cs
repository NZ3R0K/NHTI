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
		float deg = Math.ToDegrees(rad);

		return deg;
	}

	public static float LineToAngle(Line line)
	{
		return V3ToAngle(line.start, line.end);
	}

	public static Vector3 RotatePoint(Vector3 Center, float angle, Vector3 pointIN)
	{
		//Convert angle degrees to radians
		float radians = Math.ToRadians(angle);

		pointIN.x -= Center.x;
		pointIN.y -= Center.y;

		float xnew = pointIN.x * Mathf.Cos(radians) - pointIN.y * Mathf.Sin(radians);
		float ynew = pointIN.x * Mathf.Sin(radians) + pointIN.y * Mathf.Cos(radians);

		return new Vector3(xnew + Center.x, ynew + Center.y);
	}

	public static Vector3 CircleRadiusPoint(Vector3 Center, float angle, float radius)
	{
		//Used to draw object from top of screen
		angle += 90;

		return new Vector3(Center.x + (radius * Mathf.Cos(Math.ToRadians(angle))),
						   Center.y + (radius * Mathf.Sin(Math.ToRadians(angle))));
	}

	public static Vector3 EllipseRadiusPoint(Vector3 Center, float angle, Vector3 Axis)
	{
		return new Vector3(Center.x + (Axis.x * Mathf.Sin(Math.ToRadians(angle))),
						   Center.y + (Axis.y * Mathf.Cos(Math.ToRadians(angle))));
	}
}
