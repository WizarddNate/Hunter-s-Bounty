using System;
using UnityEngine;
using UnityEngine.Windows;

[Serializable]
public class PlayerMoving : BaseState
{
    private MovementSM _sm;
    

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;

        Debug.Log("Current movement state: moving!");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //transition to "idle" state if input = 0
        if (_sm._inputXZ == Vector3.zero)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        CalculateSpeed();
        Move();

    }
    private void CalculateSpeed()
    {
        
        if (_sm._inputXZ == Vector3.zero && _sm._currentSpeed > 0) //decellerate
        {
            _sm._currentSpeed -= _sm._deceleration * Time.deltaTime;
        }
        else if (_sm._inputXZ != Vector3.zero && _sm._currentSpeed < _sm.maxSpeed) //accellerate
        {
            _sm._currentSpeed += _sm._acceleration * Time.deltaTime;
        }

        _sm._currentSpeed = Mathf.Clamp(_sm._currentSpeed, 0, _sm.maxSpeed);
    }

    //apply speed, move foward and dash
    private void Move()
    {

        Vector3 moveDirection = _sm.transform.forward * _sm._currentSpeed * _sm._inputXZ.magnitude * Time.deltaTime + _sm._velocity;

        _sm._characterController.Move(moveDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
