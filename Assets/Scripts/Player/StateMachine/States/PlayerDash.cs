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

        _sm.isDashing = true;
        _sm.canDash = false;
        startTime = Time.time;

        //change animation
        _sm.animator.SetBool("isDashing", true);
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

            //disable collider
            _sm._characterController.detectCollisions = false; //temp solution as you can only dash through other rigidbodies, not all colliders

            Vector3 moveDirection = _sm.transform.forward * _sm.dashSpeed * Time.fixedDeltaTime + _sm._velocity;

            _sm._characterController.Move(moveDirection);

            return;
        }

        //Finish dash!
        _sm._characterController.detectCollisions = true;
        _sm.isDashing = false;


    }

    public override void Exit()
    {
        base.Exit();
        _sm.animator.SetBool("isDashing", false);
    }
}

