using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    Collider _col;
    bool _isFinished = false;

    [Header("Next level name")]
    public string lvlName;

    GameObject _lm;
    LevelManager _lmScript;
    
    private void Awake()
    {
        //find all active gameobjects with the tag
        GameObject[] foundObjectsArray = GameObject.FindGameObjectsWithTag("Enemy");

        //convert array to list
        enemies.AddRange(foundObjectsArray);

        _isFinished = false;
    }

    private void Start()
    {
        _lm = GameObject.Find("LevelManager");
        _lmScript = _lm.GetComponent<LevelManager>();

        _col = GetComponent<Collider>();
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
            if (!_isFinished)
            {
                Debug.Log("Level cleared!");
                _isFinished = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isFinished && other.CompareTag("Player"))
        {
            Debug.Log("loading next level!");
            _lmScript.LoadLevel(lvlName);
        }
    }
}
