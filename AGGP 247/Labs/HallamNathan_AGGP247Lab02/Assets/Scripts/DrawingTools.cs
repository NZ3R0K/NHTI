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
}
