using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // If another instance exists, destroy this one
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Make the GameManager persistent

        //find player and save them
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        if (player != null) 
        {
            DontDestroyOnLoad(player);
            Debug.Log("player protected");
        }
    }
}

