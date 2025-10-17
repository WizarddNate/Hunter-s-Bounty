using System;
using UnityEngine;

[Serializable]
public class Attacking : BaseState
{
    [Header("Attacking")]
    //public EnemyAttack attack;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [Header("Damage")]
    public int damage;
    public PlayerHealth playerHealth;

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (!alreadyAttacked)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
