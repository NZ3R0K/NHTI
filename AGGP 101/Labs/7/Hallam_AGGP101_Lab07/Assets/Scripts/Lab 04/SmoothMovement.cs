using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
	public Vector3 rotationSpeed;
	public float movementSpeed = 5.0f;

	public void Update()
	{
		if (Input.GetKey(KeyCode.W)) // Move Forward
		{
			Move(1.0f);
			Debug.Log("W Pressd");
		}

		if (Input.GetKey(KeyCode.S)) // Move Backward
		{
			Move(-1.0f);
			Debug.Log("S Pressd");
		}

		if (Input.GetKey(KeyCode.A)) // Rotate Left
		{
			Rotate(-1);
			Debug.Log("A Pressd");
		}

		if (Input.GetKey(KeyCode.D)) // Rotate Right
		{
			Rotate(1);
			Debug.Log("D Pressd");
		}

		/*if (Input.GetKey(KeyCode.Q)) // Strafe Left
		{
			Strafe(1);
			Debug.Log("Q Pressd");
		}

		if (Input.GetKey(KeyCode.E)) // Strafe Right
		{
			Strafe(-1);
			Debug.Log("E Pressd");
		}*/
	}

	public void Move(float value)
	{
		Vector3 location = gameObject.transform.position;

		location += (gameObject.transform.forward * movementSpeed * value * Time.deltaTime);

		gameObject.transform.position = location;
	}

	public void Rotate(float value)
	{
		transform.Rotate(value * rotationSpeed * Time.deltaTime);
	}

	/*public void Strafe(float value)
	{
		Vector3 location = gameObject.transform.right;

		location += (gameObject.transform.right * value * Time.deltaTime);

		gameObject.transform.right = location;
	}*/
}