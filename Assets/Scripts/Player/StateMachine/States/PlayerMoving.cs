using System;
using UnityEngine;

[Serializable]
public class PlayerMoving : BaseState
{
    private MovementSM _sm;
    

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //transition to "idle" state if input = 0
        if (_sm._currentSpeed == 0)
        {
            stateMachine.ChangeState(_sm.idleState);
            Debug.Log("Current state: idle!");
        }
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
