using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShard : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController pc = other.gameObject.GetComponent<PlayerController>();
		if (pc)
		{
			Debug.Log("Currency");
			pc.IncreaseShards();
			Destroy(this.gameObject);
		}
	}
}
