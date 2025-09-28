using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UISceneManager : MonoBehaviour
{
    internal static void LoadScene(string v, float levelNum)
    {
        throw new NotImplementedException();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

}
