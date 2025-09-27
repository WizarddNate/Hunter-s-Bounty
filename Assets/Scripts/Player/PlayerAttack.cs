using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
    }

    private void Start()
    {
        meleeWeaponCollider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        //enable melee attack 
        meleeAttack = inputActions.Player.MeleeAttack;
        meleeAttack.Enable();
        meleeAttack.performed += MeleeAttack;

    }
    private void OnDisable()
    {
        meleeAttack.Disable();
    }

    void MeleeAttack(InputAction.CallbackContext context)
    {
        Debug.Log("slash!!");
        //play animation

        //temp
        StartCoroutine(SlashAttack());
    }

    //create slashing hitbox (TEMP)
    private IEnumerator SlashAttack()
    {
        meleeWeaponCollider.enabled = true;

        yield return new WaitForSeconds(0.5f);

        meleeWeaponCollider.enabled = false;
    }

   
    //detect collison from hitbox.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            MeleeAttackEnemy();
        }
    }

    //if collision = enemy: do damage
    public void MeleeAttackEnemy()
    {
        Debug.Log("enemy hit!");
    }

    
}
