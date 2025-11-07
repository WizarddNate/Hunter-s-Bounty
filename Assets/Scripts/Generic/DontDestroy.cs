using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance = null;

    void Awake()
    {
        //make sure there is always a level manager, but only one

        if (instance == null)
        {

            Debug.Log("Singleton init");

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
