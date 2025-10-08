using System;
using UnityEngine;

[Serializable]
public class PlayerIdle : BaseState
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

        //transition to "moving" state if input != 0
        if (_sm._currentSpeed != 0)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
            Debug.Log("Current state: moving!");
        }

    }
}
