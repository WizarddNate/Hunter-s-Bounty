using System;
using UnityEngine;
using UnityEngine.Windows;

[Serializable]
public class PlayerIdle : BaseState
{
    private MovementSM _sm;


    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;

        _sm._currentSpeed = 0;
        Debug.Log("Current movement state: idle!");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //transition to "moving" state if input != 0
        if (_sm._inputXZ != Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }

    }
}
