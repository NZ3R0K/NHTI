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
}
