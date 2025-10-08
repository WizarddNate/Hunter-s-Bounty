using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;

    //loading screen. Probably wont be needed. 
    //[SerializeField] private GameObject _loaderCanvas;

    void Awake()
    {
        //make sure there is always a level manager, but only one
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
