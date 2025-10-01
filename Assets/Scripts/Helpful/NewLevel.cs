using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


/// <summary>
/// Old level Manager from game jam. DO NOT USE.
/// </summary>
public class NewLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something has entered");

        if (other.CompareTag("Player"))
        {
            var lvlNum = (LevelManager.Level)UnityEngine.Random.Range(0, 1);

            Debug.Log("level num: " + lvlNum);


            //LevelManager.Instance.LoadLevel(LevelManager.Level.lvlNum);
        }
    }
}
