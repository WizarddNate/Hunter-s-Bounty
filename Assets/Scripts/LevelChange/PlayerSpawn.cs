using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject _player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("FindPlayer", 0.6f);
    }

    void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player == null)
        {
            Debug.LogError("Player not found");
        }
        else
        {
            _player.transform.position = transform.position;
        }
    }

}
