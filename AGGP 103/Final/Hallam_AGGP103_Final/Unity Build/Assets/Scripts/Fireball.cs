using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Projectile;
    private Vector2 lookDirection;
    private float lookAngle;

	private void Update()
	{
		lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

		if (Input.GetMouseButtonDown(0))
		{
			FireProjectile();
		}
	}

	private void FireProjectile()
	{
		GameObject fireball = Instantiate(Projectile, SpawnPoint.position, SpawnPoint.rotation);
		fireball.GetComponent<Rigidbody2D>().velocity = SpawnPoint.up * 10f;
	}
}
