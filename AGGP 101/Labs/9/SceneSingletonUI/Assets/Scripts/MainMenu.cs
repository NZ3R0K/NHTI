using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject TheCanvas;
    public GameObject MainMenuPanel;
    public GameObject ExitPanel;

    public static MainMenu instance; 

    string MainMenuScene = "MainMenu";
    string Red_Room = "Room_Red";

    private void Awake()
    {
        // check if there's an instance already
        if (instance == null)
        {
            // Setting this to be our instance
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // Getting rid of extra instance
            Destroy(gameObject); 
        }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);

        MainMenuPanel.SetActive(true);
        ExitPanel.SetActive(false);
    }
	
	public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        ExitPanel.SetActive(true);
        SceneManager.LoadScene(Red_Room); 

    }

    public void EndGame()
    {
        ExitPanel.SetActive(false);
        SceneManager.LoadScene(MainMenuScene);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (MainMenuScene == scene.name)
        {
            Debug.Log("It's the MainMenu!");
            MainMenuPanel.SetActive(true);
            ExitPanel.SetActive(false);
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
}
