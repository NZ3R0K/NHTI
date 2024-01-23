using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpawner : MonoBehaviour
{
	public GameObject DiskPrefab;

	//public Transform SpawnPoint;
	public GameObject SpawnLocation;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnDisk();
		}
	}

	void SpawnDisk()
	{
		Instantiate(DiskPrefab,							//Object to Spawn
					SpawnLocation.transform.position,	//Position to Spawn Object
					SpawnLocation.transform.rotation);	//Rotation to Spawn Object

		/*
		 If rotation doesn't matter use
		 Quarternion Identities
		 */
	}
}
