using System;
using UnityEngine;

[Serializable]
public class PlayerActionIdle : BaseState
{
    private ActionsSM _sm;

    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        Debug.Log("Current action state: idle!");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (_sm._meleeInput.IsPressed())
        {
            stateMachine.ChangeState(((ActionsSM)stateMachine).meleeAttackState);
        }
    }
}
