using System;
using UnityEngine;

[Serializable]
public class TakingDamage : BaseState
{
    UniversalEnemyData _ed;
    public override void Enter()
    {
        base.Enter();

        _ed = stateMachine.GetComponent<UniversalEnemyData>();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //Debug.Log("state machine? - " + _ed.health);
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
