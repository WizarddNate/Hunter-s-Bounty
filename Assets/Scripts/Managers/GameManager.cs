using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject deathscreen;

    public void Awake()
    {
        
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

