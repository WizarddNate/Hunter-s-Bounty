using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [Header("text")]
    public TextMeshProUGUI finalTimeText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI newHighScoreAnnounceText;

    private float finalTime;
    private float _highscore;

    [Header("Timer")]
    public Timer timer;

    void Awake()
    {
        Debug.Log("highscore: " + _highscore);

        DontDestroyOnLoad(gameObject);
    }

        void Start()
    {
        newHighScoreAnnounceText.enabled = false;
    }

    public void SetFinalTime()
    {
        finalTime = timer.currentTime;
        Time.timeScale = 0f;

        TimeSpan time = TimeSpan.FromSeconds(finalTime);
        finalTimeText.text = ("Your Time: " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());


        if (finalTime >= _highscore)
        {
            _highscore = finalTime;

            newHighScoreAnnounceText.enabled = true;
        }

        TimeSpan bestTime = TimeSpan.FromSeconds(finalTime);
        highscoreText.text = (("High Score: " + bestTime.Minutes.ToString() + ":" + bestTime.Seconds.ToString() + ":" + bestTime.Milliseconds.ToString()));
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}