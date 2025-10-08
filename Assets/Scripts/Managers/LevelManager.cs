using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    //loading screen. Probably wont be needed. 
    //[SerializeField] private GameObject _loaderCanvas;

    void Awake()
    {
        //make sure there is always a level manager, but only one
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum Menu
    {
        MainMenu = 0
    }
    public enum Level 
    {
        Level01 = 0,
        Level02 = 1
    }

    //load any scene
    public void LoadLevel(string lvlName)
    {
 
        SceneManager.LoadScene(lvlName);
        Debug.Log("Loading scene: " +  lvlName);
    }

    //load level 1. Good for starting the game or restarting on death
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Level.Level01.ToString());
    }

    //load main menu. Nice and easy for quit buttons
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Menu.MainMenu.ToString());
    }

    //load next scene in index.
    //probably not ever needed, but could be useful for story events
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
