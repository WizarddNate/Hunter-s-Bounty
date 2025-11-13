using System;
using System.Collections;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class PlayerDash : BaseState
{
    private MovementSM _sm;
    float startTime;

    //raycast
    float _maxDistance = 30f;
    LayerMask _maskToHit;
    bool _isHittingGround;
    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;

        Debug.Log("Current movement state: dashing!");

        _sm.isDashing = true;
        _sm.canDash = false;
        startTime = Time.time;

        _maskToHit = LayerMask.GetMask("Ground");

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

        Quaternion tiltRot = Quaternion.AngleAxis(35f, _sm.transform.right);
        Vector3 titledDir = tiltRot * _sm.transform.forward;

        if (Physics.Raycast(_sm.transform.position, titledDir, out RaycastHit hit, _maxDistance, _maskToHit))
        {
            Debug.DrawRay(_sm.transform.position, titledDir);
            //Debug.Log("something was hit!");
            _isHittingGround = true;
        }
        else _isHittingGround = false;

        if (Time.time < startTime + _sm.dashDuration && _isHittingGround)
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
        _sm.canDash = true;
    }
}

