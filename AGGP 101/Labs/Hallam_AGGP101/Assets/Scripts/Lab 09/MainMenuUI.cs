using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void LoadCombat()
	{
		SceneManager.LoadScene("Combat");
	}

	public void LoadPlinko()
	{
		SceneManager.LoadScene("Plinko");
	}

	public void LoadSoccer()
	{
		SceneManager.LoadScene("SoccerField");
	}

	public void QuitApplication()
	{
		Debug.Log("Quit App");
		Application.Quit();

#if UNITY_EDITOR
		if (UnityEditor.EditorApplication.isPlaying)
		{
			UnityEditor.EditorApplication.isPlaying = false;
		}
#endif
	}
}
