using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewLevel : MonoBehaviour
{
    public List<string> levels = new List<string>();

    private void Awake()
    {
        levels.Add("Level1");
        levels.Add("Level2");
        levels.Add("Level3");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something has entered");

        if (other.CompareTag("Player"))
        {
            
        }
    }
}
