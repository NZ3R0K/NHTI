using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMouseTest : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			print("Spacebar Pressed");
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			print("Mouse Down");
		}


	}
}
