using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    //loading screen. Probably wont be needed. 
    //[SerializeField] private GameObject _loaderCanvas;

    public List<string> levelsList = new List<string>();

    void Awake()
    {
        //make sure there is always a level manager, but only one
        /*
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } */
    }


    /// <summary>
    /// Loading scenes functionality
    /// </summary>

    //load any scene
    public void LoadLevel(string lvlName)
    {
 
        SceneManager.LoadScene(lvlName);
        Debug.Log("Loading scene: " +  lvlName);
    }

    //load level 1. Good for starting the game or restarting on death
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level01");
    }

    //load main menu. Nice and easy for quit buttons
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //load next scene in index.
    //probably not ever needed, but could be useful for story events
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
