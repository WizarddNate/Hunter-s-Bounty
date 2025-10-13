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

        //_sm._currentSpeed = 0;
        _sm.canDash = true; //remove this once dash cooldown is made
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

        //transition to "dash" state if input is pressed
        if (_sm._dashInput.IsPressed() && _sm.canDash)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).dashState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        //decrease speed if still moving
        if (_sm._inputXZ == Vector3.zero && _sm._currentSpeed > 0) //decellerate
        {
            _sm._currentSpeed -= _sm._deceleration * Time.deltaTime;
        }
    }
}
