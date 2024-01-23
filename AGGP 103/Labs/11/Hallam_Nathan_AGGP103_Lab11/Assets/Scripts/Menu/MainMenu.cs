﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}

	public void BackToMain()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
	}

	public void Quit()
	{
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}



}
