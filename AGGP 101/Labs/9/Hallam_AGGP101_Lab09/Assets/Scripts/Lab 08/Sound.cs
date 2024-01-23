using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
	public GameObject MusicGameObject;

	AudioSource musicSource;

	// Use this for initialization
	void Start()
	{
		musicSource = MusicGameObject.GetComponent<AudioSource>();
	}


	// Update is called once per framevoid Update ()    
	void Update()
	{
		// Toggle Spacial Blend        
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ToggleSpacialBlend();
		}
	}

	public void ToggleSpacialBlend()
	{
		if (musicSource.spatialBlend == 1)
		{
			musicSource.spatialBlend = 0;
			Debug.Log("Spatical Blend = 0 (2d)");
		}
		else
		{
			musicSource.spatialBlend = 1;
			Debug.Log("Spatical Blend = 1 (3d)");
		}
	}
}