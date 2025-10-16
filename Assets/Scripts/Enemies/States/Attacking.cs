using System;
using UnityEngine;

[Serializable]
public class Attacking : BaseState
{
    [Header("Attacking")]
    //public EnemyAttack attack;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();


    }

    public override void Exit()
    {
        base.Exit();
    }
}
