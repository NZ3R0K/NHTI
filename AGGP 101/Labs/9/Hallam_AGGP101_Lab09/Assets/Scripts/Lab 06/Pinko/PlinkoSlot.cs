using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoSlot : MonoBehaviour
{
	public int SlotScore;
	public float waitOnDestroy = 2.0f;  // In Seconds

	private void OnTriggerEnter(Collider other)
	{
		Debug.LogWarning("Found: " + other.name);
		PlinkoDisk pd = other.gameObject.GetComponentInParent<PlinkoDisk>();
	if (pd)
		{
			Destroy(pd.gameObject, waitOnDestroy); //Destroy whole object - just pd will remove script. waitOnDestroy waits to trigger Destroy
			Debug.Log("pts+ " + SlotScore);
			PlinkoManager.self.AddScore(SlotScore);
		}
	}

}
