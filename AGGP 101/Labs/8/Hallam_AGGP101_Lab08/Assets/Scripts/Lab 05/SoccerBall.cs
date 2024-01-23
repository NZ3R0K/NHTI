using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
	Rigidbody rigBod;
	Vector3 startLocation;
	Quaternion startRotation;

	void Start()
	{
		rigBod = gameObject.GetComponent<Rigidbody>();
		if (!rigBod)
		{
			Debug.LogError("ERROR - Missing Rigidbody!");
		}
		//Set starting stats
		startRotation = gameObject.transform.rotation;
		startLocation = gameObject.transform.position;
	}

	public void Reset()
	{
		//Set ball at start position on reset
		gameObject.transform.rotation = startRotation;
		gameObject.transform.position = startLocation;

		//Stop ball movement on reset
		rigBod.velocity = Vector3.zero;
		rigBod.angularVelocity = Vector3.zero;
	}
}
