using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject _player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _player.transform.position = transform.position;
    }

}
