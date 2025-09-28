using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public List<string> levels = new List<string>();

    private void Awake()
    {
        levels.Add("Level1");
        levels.Add("Level2");
        //levels.Add("Level3");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something has entered");

        if (other.CompareTag("Player"))
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        //Debug.Log("level count = " + levels.Count);

        int randomIndex = Random.Range(0,levels.Count);

        //Debug.Log("Index = " + randomIndex);

        Debug.Log("Loading scene" + levels[randomIndex]);
        SceneManager.LoadScene(levels[randomIndex]);
    }
}
