using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
	public static bool NearlyEqual(float f1, float f2)
	{
		float check = f1 - f2;
		return (Mathf.Abs(check) < 0.001);
	}

	//https://www.geeksforgeeks.org/check-whether-a-given-point-lies-inside-a-triangle-or-not/
	public static bool isInsideTriangle(Vector3 point, Vector3 Verticie1, Vector3 Verticie2, Vector3 Verticie3)
	{
		/* Calculate area of triangle ABC */
		float A = AreaOfTriangle(Verticie1, Verticie2, Verticie3);

		/* Calculate area of triangle PBC */
		float A1 = AreaOfTriangle(point, Verticie2, Verticie3);

		/* Calculate area of triangle PAC */
		float A2 = AreaOfTriangle(Verticie1, point, Verticie3);

		/* Calculate area of triangle PAB */
		float A3 = AreaOfTriangle(Verticie1, Verticie2, point);

		/* Check if sum of A1, A2 and A3 is same as A */
		return NearlyEqual(A, A1 + A2 + A3);
	}

	public static float AreaOfTriangle(Vector3 Verticie1, Vector3 Verticie2, Vector3 Verticie3)
	{
		return Mathf.Abs((Verticie1.x * (Verticie2.y - Verticie3.y) +
						 Verticie2.x * (Verticie3.y - Verticie1.y) +
						 Verticie3.x * (Verticie1.y - Verticie2.y)) / 2f);
	}
}
