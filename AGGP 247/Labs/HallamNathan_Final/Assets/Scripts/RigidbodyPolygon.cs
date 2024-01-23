using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RigidbodyPolygon : RigidbodyObject
{
	public List<Vector3> Verticies = new List<Vector3>();

	//https://www.youtube.com/watch?v=7Ik2vowGcU0
	public bool ShapeOverlap_SAT(RigidbodyPolygon me, RigidbodyPolygon other)
	{
		RigidbodyPolygon Object1 = me;
		RigidbodyPolygon Object2 = other;

		for (int shape = 0; shape < 2; shape++)
		{
			if (shape == 1)
			{
				Object1 = other;
				Object2 = me;
			}

			for (int a = 0; a < Object1.Verticies.Count; a++)
			{
				int b = (a + 1) % Object1.Verticies.Count;
				Vector3 axisProj = new Vector3(-(Object1.Verticies[b].y - Object1.Verticies[a].y), Object1.Verticies[b].x - Object1.Verticies[a].x);

				float min_r1 = Mathf.Infinity;
				float max_r1 = -Mathf.Infinity;

				for (int p = 0; p < Object1.Verticies.Count; p++)
				{
					float q = (Object1.Verticies[p].x * axisProj.x + Object1.Verticies[p].y * axisProj.y);
					min_r1 = Math.Min(min_r1, q);
					max_r1 = Math.Max(max_r1, q);
				}

				float min_r2 = Mathf.Infinity;
				float max_r2 = -Mathf.Infinity;

				for (int p = 0; p < Object2.Verticies.Count; p++)
				{
					float q = (Object2.Verticies[p].x * axisProj.x + Object2.Verticies[p].y * axisProj.y);
					min_r2 = Math.Min(min_r2, q);
					max_r2 = Math.Max(max_r2, q);
				}

				if (!(max_r2 >= min_r1 && max_r1 >= min_r2)) return false;
			}
		}

		return true;
	}
}

public static class RigidbodyPolygonExtensions
{
	/// <summary>
	/// Used to see if a point is inside a polygon
	/// </summary>
	/// <param name="point">The point to look for</param>
	/// <param name="A">Verticie A</param>
	/// <param name="B">Verticie B</param>
	/// <returns>True if point is to the right of the given line AB</returns>
	public static bool isRight(this RigidbodyPolygon polygon, Vector3 point)
	{
		if (((polygon.Verticies[0].x - point.x) * (polygon.Verticies[1].y - point.y) - (polygon.Verticies[1].x - point.x) * (polygon.Verticies[0].y - point.y)) > 0)
			return true;

		return false;
	}
}