using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }
}

