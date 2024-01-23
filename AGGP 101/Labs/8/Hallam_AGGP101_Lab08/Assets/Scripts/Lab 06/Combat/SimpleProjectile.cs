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
		CombatController cc = other.gameObject.GetComponentInParent<CombatController>();
		
		if (cc)	//If there is a combat controller, call the Reset function within the controller.
		{
			cc.Reset();
		}

		Destroy(gameObject);
	}
}