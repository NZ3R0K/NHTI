using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MRigidbody
{
	public float Mass;
//	public float Drag;
//	public float AngularDrag;
	public float Speed;
	public Vector3 Velocity;
	public Vector3 AngularVelocity;
	public bool useGravity = false;
	public bool isStatic = false;


	public Vector3 force { get; private set; }

	public void AddForce(Vector3 Direction)
	{
		force += Direction;
	}

	public void Update(MTransform transform, Vector3 gravity)
	{
		Velocity += force * Time.fixedDeltaTime;

		if (!isStatic) Velocity += gravity * Time.deltaTime;
		transform.Position += Velocity * Time.deltaTime;

		transform.Rotation += AngularVelocity * Time.deltaTime;

		force = Vector3.zero;
	}
}