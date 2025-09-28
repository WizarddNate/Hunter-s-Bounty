using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider other)
    {
        Debug.Log("pipipfkpfkfok");

        //Instantiate(pickupEffect, transform.position, transform.rotation);

        other.transform.localScale *= multiplier;

        Destroy(gameObject);
    }

}
