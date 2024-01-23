using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

	readonly PlayerController pc;
	public int loadScene = 0;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Debug.LogWarning("Player Entered the Portal!");
			SceneManager.LoadScene(loadScene);
		}
	}


}
