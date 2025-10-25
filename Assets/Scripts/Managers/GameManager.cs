using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject deathscreen;

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
        if (deathscreen == null)
        {
            deathscreen = GameObject.Find("DeathScreen");
        }
        
        if (deathscreen != null) 
        {
            DontDestroyOnLoad(deathscreen);
            Debug.Log("deathscreen");
        } 
    }
}

