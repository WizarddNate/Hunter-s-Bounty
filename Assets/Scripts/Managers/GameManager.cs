using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int currentLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
 


}

