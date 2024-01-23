/*Bug List
 * - Reaching destination in reverse exceeds the destination
 * - Capsule locks to location if howCloseIsCloseEnough is too close to Zero. (Spazum)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : MonoBehaviour
{
	public GameObject targetA, targetB;
	GameObject currentTarget;
	bool isMovingToTargetA;
	public bool hasDynamicDirection = true;
	public float movementSpeed, howCloseIsCloseEnough;
	Vector3 moveDirection;
	public bool autoPilot;

	public void Start()
	{
		currentTarget = targetA;
		isMovingToTargetA = true;
	}

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

		if (Input.GetKeyDown(KeyCode.Space))
		{
			NextTarget();
			Debug.Log("Space Pressed");
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

	// Returns nothing. Updates target by switching it between targetA and targetB.
	public void NextTarget()
	{
		if (isMovingToTargetA == true)
		{
			isMovingToTargetA = false;
			currentTarget = targetB;
		}
		else
		{
			isMovingToTargetA = true;
			currentTarget = targetA;
		}
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



	/*
		void ShowAddExample()
		{
			Vector2 VectorA = Vector2.zero;
			Vector2 VectorB = Vector2.zero;
			VectorA.Set(1, 1);
			VectorB.Set(2, 3);
			Vector2 VectorC = VectorA + VectorB;
			Debug.Log("Vector C Result : " + VectorC.ToString());
		}

		void ShowMagnitudeExample()
		{
			Vector2 exampleVector = Vector2.zero;
			exampleVector.Set(1, 1);
			Debug.Log("[1,1] - Distance: " + exampleVector.magnitude);
			exampleVector.Set(1, 2);
			Debug.Log("[1,2] - Distance: " + exampleVector.magnitude);
			exampleVector.Set(2, 3); Debug.Log("[2,3] - Distance: " + exampleVector.magnitude);
		}

		void ShowScaleExample()
		{
			Vector2 exampleVector = Vector2.zero;
			exampleVector.Set(1, 1);
			Debug.Log(exampleVector.ToString() + " - Distance: " + exampleVector.magnitude);
			exampleVector = exampleVector * 3;
			Debug.Log(exampleVector.ToString() + " - Distance: " + exampleVector.magnitude);
			exampleVector = exampleVector / 3;
			Debug.Log(exampleVector.ToString() + " - Distance: " + exampleVector.magnitude);
		}

		void ShowNormalizeExample()
		{
			Vector2 exampleVector = Vector2.zero;
			exampleVector.Set(1, 1);
			Debug.Log("[1,1] - Distance: " + exampleVector.magnitude);
			exampleVector = exampleVector.normalized;
			Debug.Log("[1,1] - Normalized Distance: " + exampleVector.magnitude);
			Debug.Log("[1,1] - Normalized : " + exampleVector.ToString());
		}
	*/
}
