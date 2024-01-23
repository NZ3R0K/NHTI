/* Bugs :
 * Deletes Parent instead of bullet
 * Does not spawn proj?
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
	public float damage = 10;
	public float lifetime = 8;
	public float projectileSpeed = 25f;

	public GameObject ExplosionPrefab;
	public GameObject SpawnLocation;


	void Update()
	{
		Destroy(gameObject, lifetime);
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();
		rb.velocity = gameObject.transform.forward * projectileSpeed;
	}

	void OnTriggerEnter(Collider other)
	{
//		Instantiate(ExplosionPrefab,                    //Object to Spawn
//		SpawnLocation.transform.position,   //Position to Spawn Object
//		SpawnLocation.transform.rotation);  //Rotation to Spawn Object

		Destroy(gameObject);
	}
}