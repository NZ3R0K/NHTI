using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseIG : MonoBehaviour
{
	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject settingsMenu;
	public GameObject HUD;
	private PlayerController pc;

	public int pauseIndex = 0;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			Debug.Log("Escape Pressed");
			if (gameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}

			if (pauseIndex == 0)
			{
				gameIsPaused = false;
			}
			else if (pauseIndex == 1)
			{
				gameIsPaused = true;
			}
			else if (pauseIndex == 2)
			{
				pauseIndex = 1;
				settingsMenu.SetActive(false);
				pauseMenuUI.SetActive(true);
			}
		}
	}

	public void Resume()
	{
		if (pauseIndex == 1)
		{
			pauseMenuUI.SetActive(false);
			HUD.SetActive(true);
			Time.timeScale = 1f;
			pauseIndex = 0;
		}
	}

	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		HUD.SetActive(false);
		Time.timeScale = 0f;
		pauseIndex = 1;
	}

	public void IncreaseIndexOne()
	{
		pauseIndex++;
	}

	public void DecreaseIndexOne()
	{
		pauseIndex--;
	}


}
