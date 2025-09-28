/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Status Effect")]
public class SlowdownStatus : ScriptableObject
{
    public CharacterController characterController;
    public CharacterController EssenceCounter;
    public float slowMultiplier = 1.4f;
    public float slowDuration = 0.4f;

    public GameObject onSpell;
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

        GetComponent<EnemyH>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        //Debug.Log("pipipfkpfkfok");
        other.transform.localScale /= multiplier;
        Destroy(gameObject);
    }

} */
