using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public Collider col;

    private void Awake()
    {
        //find all active gameobjects with the tag
        GameObject[] foundObjectsArray = GameObject.FindGameObjectsWithTag("Enemy");

        //convert array to list
        enemies.AddRange(foundObjectsArray);
    }

    private void Update()
    {
        CheckForMissing();
    }

    public void CheckForMissing()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
            }
        }

        if (enemies.Count <= 0)
        {
            Debug.Log("Level cleared!");
            gameObject.SetActive(false);
        }
    }

}
