using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject aboutScreen;
    public GameObject deathScreen;
    public GameObject HUD;

    public GameObject player;
    public MovementSM mSM;

    private void Start()
    {
        startScreen.SetActive(true);
        aboutScreen.SetActive(false);
        deathScreen.SetActive(false);
        HUD.SetActive(false);

        player = GameObject.FindWithTag("Player");
        mSM = player.GetComponent<MovementSM>();

        mSM.inputActions.FindActionMap("Player").Disable();
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
    }

    public void Quit()
    {
        Application.Quit();
    }
}
