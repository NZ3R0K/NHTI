using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
	public float damage = 5;

	void OnTriggerStay2D(Collider2D other)
	{
		PlayerController pc = other.gameObject.GetComponent<PlayerController>();
		KillProj kp = other.gameObject.GetComponent<KillProj>();

		if (pc)
		{
			pc.Damage(damage);
			pc.effectPoison = true;
			pc.debuffTime = pc.debuffSetTime;
		}

		if (kp)
		{
			Destroy(kp.gameObject);
			Destroy(this.gameObject);
		}
	}
}