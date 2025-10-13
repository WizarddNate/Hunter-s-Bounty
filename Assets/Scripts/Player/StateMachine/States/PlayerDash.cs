using System;
using System.Collections;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class PlayerDash : BaseState
{
    private MovementSM _sm;
    float startTime;

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;

        Debug.Log("Current movement state: dashing!");

        _sm.canDash = false;
        startTime = Time.time;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
   

        if (Time.time < startTime + _sm.dashDuration)
        {
            Vector3 moveDirection = _sm.transform.forward * _sm.dashSpeed * Time.fixedDeltaTime + _sm._velocity;

            _sm._characterController.Move(moveDirection);

            return;
        }

        Debug.Log("Finish dash!");

        //return to previous state
        if (_sm._inputXZ != Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
        else if (_sm._inputXZ == Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
        }
    }
}

