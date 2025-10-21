using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Attacking : BaseState
{
    [Header("Attacking")]
    public float attackChargeTime = 0.6f;
    float attackStartTime = 0;
    bool isAttacking;
    
    


    [Header("Damage")]
    public int damage;
    public PlayerHealth playerHealth;

    public override void Enter()
    {
        base.Enter();
        
        if (attackStartTime == 0)
        {
            attackStartTime = Time.time;
        }
        isAttacking = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Time.time < attackStartTime + attackChargeTime)
        {
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }

        if(isAttacking)
        {
            //attack!
            playerHealth.TakeDamage(damage);
        }
        
    }

    public override void Exit()
    {
        base.Exit();

        isAttacking = false;
    }
}
