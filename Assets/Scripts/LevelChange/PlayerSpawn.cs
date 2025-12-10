using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject _player;


    void Start()
    {
        Invoke("FindPlayer", 0.1f);
    }

    void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player != null)
        {
            _player.transform.position = transform.position;
        }
        else return;
    }

}
