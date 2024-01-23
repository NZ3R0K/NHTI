using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MTransform
{
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Scale;

	[HideInInspector] public Vector3 up 
	{
		get { return TransformUP(); }
	}

	public void Update()
	{
		TransformRotation();
	}

	void TransformRotation()
	{
		if (Rotation.z >= 180) Rotation.z -= 360;
		if (Rotation.z < -180) Rotation.z += 360;
	}

	Vector3 TransformUP()
	{
		Vector3 up = Vector3.zero;

		up.x = -Mathf.Sin(Rotation.z * Mathf.Deg2Rad);
		up.y = Mathf.Cos(Rotation.z * Mathf.Deg2Rad);

		if (Helper.NearlyEqual(up.x, -1)) up.x = -1;
		if (Helper.NearlyEqual(up.x, 0)) up.x = 0;
		if (Helper.NearlyEqual(up.x, 1)) up.x = 1;
		if (Helper.NearlyEqual(up.y, -1)) up.y = -1;
		if (Helper.NearlyEqual(up.y, 0)) up.y = 0;
		if (Helper.NearlyEqual(up.y, 1)) up.y = 1;

		return up;
	}

	public void Translate(Vector3 translation)
	{
		Position += translation;
	}
}
