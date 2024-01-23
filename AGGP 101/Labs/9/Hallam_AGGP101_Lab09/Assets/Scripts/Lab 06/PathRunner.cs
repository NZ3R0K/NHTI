using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRunner : MonoBehaviour
{
	public List<GameObject> goList;
	public bool hasDynamicDirection = true;
	public float movementSpeed, howCloseIsCloseEnough;
	Vector3 moveDirection;
	public bool autoPilot;

	GameObject currentTarget;

	int pathListIndex = 0;

	public void Update()
	{
		if (autoPilot == false)
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
		}
		else
		{
			hasDynamicDirection = true;
			Move(1.0f);
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			NextTarget();
			Debug.Log("W Pressed");
			Debug.Log("Target Swapped");
		}

		if (Input.GetKeyDown(KeyCode.LeftShift)) //Manual update for move direction when dynamic direction is false.
		{
			UpdateMoveDirection();
			Debug.Log("LShift Pressed");
			Debug.Log("Movement Direction Updated");
		}

		if (hasDynamicDirection == true) //If the object has dynamic direction, update move direction every frame, otherwise user needs to update with keypress.
		{
			UpdateMoveDirection();
		}

		if (IsCloseToTarget() == true) //If close to target, swap to next target
		{
			NextTarget();
		}
	}

	private void Start()
	{
		currentTarget = goList[0]; //On Start, set current target to the first item in the list.
	}

	public void NextTarget()
	{
		pathListIndex++;

		//Keep Index in set Range
		if (pathListIndex >= goList.Count)
		{
			pathListIndex = 0;
		}

		currentTarget = goList[pathListIndex];
	}

	// Takes the position of another gameobject.
	public float GetDistanceTo(GameObject otherObject)
	{
		Vector3 LineTo = otherObject.transform.position - gameObject.transform.position;
		return LineTo.magnitude;
	}

	// Returns true if the distance from the runner object to the current target is less than the movementSpeed. Else false.
	public bool IsCloseToTarget()
	{
		bool isClose = false;

		if (GetDistanceTo(currentTarget) <= howCloseIsCloseEnough / movementSpeed)
		{
			isClose = true;
		}
		return isClose;
	}

	// Gets the vector of the object to its target.
	public void UpdateMoveDirection()
	{
		moveDirection = currentTarget.transform.position - gameObject.transform.position;
		moveDirection.Normalize();

		gameObject.transform.forward = moveDirection;
	}

	public void Move(float value)
	{
		Vector3 location = gameObject.transform.position;

		location += (gameObject.transform.forward * movementSpeed * value * Time.deltaTime);

		gameObject.transform.position = location;
	}
}
