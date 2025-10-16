using System;
using UnityEngine;

[Serializable]
public class Attacking : BaseState
{
    private GenericAggroEnemySM _sm;

    public override void Enter()
    {
        base.Enter();
        _sm = (GenericAggroEnemySM)stateMachine;

        Debug.Log("enemy is attacking");
    }
}
