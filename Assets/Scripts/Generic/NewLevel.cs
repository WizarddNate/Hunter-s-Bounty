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
    [SerializeField] public bool isRandLevelSelect;
    [SerializeField] public string levelSelect;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something has entered");

        if (other.CompareTag("Player"))
        {
            if (isRandLevelSelect)
            {
                var lvlNum = (LevelManager.Level)UnityEngine.Random.Range(0, 1);

                Debug.Log("level num: " + lvlNum);


                //LevelManager.Instance.LoadLevel(LevelManager.Level.lvlNum);
            }

            else
            {
                LevelManager.Instance.LoadLevel(levelSelect);
            }
        }
    }
}
