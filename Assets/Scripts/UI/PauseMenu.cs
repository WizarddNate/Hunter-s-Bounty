using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    bool isPaused = false;

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Resume()
    {
        isPaused=false;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseResume()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        
    }
}
