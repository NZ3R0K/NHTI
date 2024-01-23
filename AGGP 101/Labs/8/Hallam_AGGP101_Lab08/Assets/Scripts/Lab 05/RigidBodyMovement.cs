/*
 Came across a movement problem when playing around, added it as a bool 'iceMode'
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
	public bool isPlayerOne = true;
	public float moveSpeed = 10;
	public float rotationSpeed = 120;

	//Input Variables
	bool forward = false;
	bool backward = false;
	bool left = false;
	bool right = false;

	float Horizontal = 0;
	float Vertical = 0;

	public bool iceMode = false;

	Rigidbody rigBod;

	void Start()
	{
		rigBod = gameObject.GetComponent<Rigidbody>();
		rigBod.constraints = RigidbodyConstraints.FreezeRotation;
	}

	void FixedUpdate()
	{
		if (isPlayerOne)
		{
			GetInputPlayer1();

			if (!iceMode)
			{
				Horizontal = 0;
				Vertical = 0;

				if (forward)
				{
					Vertical = 1;
				}
				if (backward)
				{
					Vertical = -1;
				}
				if (right)
				{
					Horizontal = 1;
				}
				if (left)
				{
					Horizontal = -1;
				}

				Move(Vertical);
				Rotate(Horizontal);
			}
			else
			{
				if (forward)
				{
					Move(1);
				}
				if (backward)
				{
					Move(-1);
				}
				if (right)
				{
					Rotate(1);
				}
				if (left)
				{
					Rotate(-1);
				}
			}
		}

		if (!isPlayerOne)
		{
			GetInputPlayer2();

			if (!iceMode)
			{
				Horizontal = 0;
				Vertical = 0;

				if (forward)
				{
					Vertical = 1;
				}
				if (backward)
				{
					Vertical = -1;
				}
				if (right)
				{
					Horizontal = 1;
				}
				if (left)
				{
					Horizontal = -1;
				}

				Move(Vertical);
				Rotate(Horizontal);
			}
			else
			{
				if (forward)
				{
					Move(1);
				}
				if (backward)
				{
					Move(-1);
				}
				if (right)
				{
					Rotate(1);
				}
				if (left)
				{
					Rotate(-1);
				}
			}
		}

		void GetInputPlayer1()
		{
			forward = Input.GetKey(KeyCode.W);
			backward = Input.GetKey(KeyCode.S);
			left = Input.GetKey(KeyCode.A);
			right = Input.GetKey(KeyCode.D);
		}

		void GetInputPlayer2()
		{
			forward = Input.GetKey(KeyCode.I);
			backward = Input.GetKey(KeyCode.K);
			left = Input.GetKey(KeyCode.J);
			right = Input.GetKey(KeyCode.L);
		}

		void Move(float value)
		{
			rigBod.velocity = gameObject.transform.forward * moveSpeed * value;
		}

		void Rotate(float value)
		{
			gameObject.transform.Rotate(Vector3.up * value * rotationSpeed * Time.deltaTime);
		}

	}
}
