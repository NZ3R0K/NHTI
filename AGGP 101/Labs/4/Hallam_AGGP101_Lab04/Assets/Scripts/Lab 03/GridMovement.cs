using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
	public Vector3 moveValue;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			transform.position += Vector3.forward;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		if (Input.GetKeyDown(KeyCode.J))
		{
			transform.position += Vector3.left;
			gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			transform.position += Vector3.back;
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			transform.position += Vector3.right;
			gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
		}
	}
}
