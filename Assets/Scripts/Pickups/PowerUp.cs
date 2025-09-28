using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 0.4f;

    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    private IEnumerator Pickup(Collider other)
    {

        //Instantiate(pickupEffect, transform.position, transform.rotation);

        other.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        Debug.Log("pipipfkpfkfok");
        other.transform.localScale /= multiplier;
        Destroy(gameObject);
    }

}
