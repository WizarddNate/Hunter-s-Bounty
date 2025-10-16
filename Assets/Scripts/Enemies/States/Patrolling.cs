using System;
using UnityEngine;

[Serializable]
public class Patrolling : BaseState
{
    [Header("Patrolling")]
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointIsSet;

    public override void Enter()
    {
        base.Enter();


        Debug.Log("enemy is searching for player");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();


    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
