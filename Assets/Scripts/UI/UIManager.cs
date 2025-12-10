using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject aboutScreen;
    public GameObject aboutBUTTON;
    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject HUD;

    public GameObject player;
    public MovementSM mSM;

    private void Start()
    {

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "StartLevel")
        {
            startScreen.SetActive(true);
            aboutBUTTON.SetActive(true);

            aboutScreen.SetActive(false);
            winScreen.SetActive(false);
            deathScreen.SetActive(false);
            HUD.SetActive(false);

            player = GameObject.FindWithTag("Player");
            mSM = player.GetComponent<MovementSM>();
            mSM.inputActions.FindActionMap("Player").Disable();
        }
    }

    /// <summary>
    /// functionality for the start menu
    /// </summary>

    public void StartButton()
    {
        Debug.Log("start game");
        mSM.inputActions.FindActionMap("Player").Enable();

        Invoke("CloseStartMenu", 0.5f);
    }

    public void CloseStartMenu()
    {
        startScreen.SetActive(false);
        HUD.SetActive(true);
    }

    public void OpenAbout()
    {
        aboutScreen.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutScreen.SetActive(false);
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
    }

    public void RestartGame()
    {
        var scriptsToDestroy = FindObjectsByType(typeof(DontDestroy), FindObjectsSortMode.None);


        foreach (DontDestroy scriptInstance in scriptsToDestroy)
        {
            Debug.Log("Found Object: " + scriptInstance.gameObject);
            Destroy(scriptInstance.gameObject);

            GameObject _lm = GameObject.Find("LevelManager");
            LevelManager _lmScript = _lm.GetComponent<LevelManager>();

            _lmScript.LoadLevel("StartLevel");
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}
