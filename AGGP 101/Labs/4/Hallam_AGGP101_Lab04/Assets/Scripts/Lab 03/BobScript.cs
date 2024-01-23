using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour
{

	public Vector3 startLocation;
	public float bobSpeed;
	public float bobHeight;
	float direction = 1;

	void Start()
	{
		//On Start, set objects starting location
		startLocation = gameObject.transform.position;
		Debug.Log(gameObject.name);
	}

	void Update()
	{
		//Retrieve Current location
		Vector3 location = gameObject.transform.position;

		//Update location
		location.y += (bobSpeed * direction * Time.deltaTime);

		//Assign Location
		gameObject.transform.position = location;

		//Reverse Direction when hitting Top or Bottom bound
		if (location.y >= (startLocation.y + bobHeight))
		{
			direction = -1;
			location.y = startLocation.y + bobHeight;
		}

		if (location.y < (startLocation.y))
		{
			direction = 1;
			location.y = startLocation.y;
		}
	}
}