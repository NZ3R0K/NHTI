using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyObject
{
	[Header("Transform")]
	public Vector3 Position;
	public Vector3 Rotation;
	public Vector3 Scale;

	protected Vector3 _oldPosition;
	protected Vector3 _oldRotation;
	protected Vector3 _oldScale;

	[HideInInspector]
	public Vector3 up
	{
		get { return TransformUP(); }
	}

	[Header("Rigidbody")]
	public float Mass;
	//	public float Drag;
	//	public float AngularDrag;
	public Vector3 Velocity;
	public Vector3 AngularVelocity;

	public bool useGravity = false;
	public bool isStatic = false;


	public Vector3 force { get; private set; }

	public void AddForce(Vector3 Direction)
	{
		force += Direction;
	}

	public virtual void Physics(World world)
	{
		if (Mass < 0.001f) Mass = 0.001f;

		Velocity += (force / Mass) * Time.fixedDeltaTime;

		if (!isStatic && useGravity) Velocity += world.Gravity * Mass * Time.deltaTime;
		if (isStatic) Velocity = Vector3.zero;

		Position += Velocity * Time.deltaTime;

		Rotation += AngularVelocity * Time.deltaTime;

		force = Vector3.zero;
	}

	Vector3 TransformUP()
	{
		Vector3 up = Vector3.zero;

		up.x = -Mathf.Sin(Math.ToRadians(Rotation.z));
		up.y = Mathf.Cos(Math.ToRadians(Rotation.z));

		if (Math.NearlyEqual(up.x, -1)) up.x = -1;
		if (Math.NearlyEqual(up.x, 0)) up.x = 0;
		if (Math.NearlyEqual(up.x, 1)) up.x = 1;
		if (Math.NearlyEqual(up.y, -1)) up.y = -1;
		if (Math.NearlyEqual(up.y, 0)) up.y = 0;
		if (Math.NearlyEqual(up.y, 1)) up.y = 1;

		return up;
	}
}
