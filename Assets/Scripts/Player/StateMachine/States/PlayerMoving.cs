using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEngine.UI.Image;

[Serializable]
public class PlayerMoving : BaseState
{
    private MovementSM _sm;

    //raycast
    float _maxDistance = 20f;
    LayerMask _maskToHit;
    bool _isHittingGround;

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;
        _sm.canDash = true; //remove this once dash cooldown is made

        _maskToHit = LayerMask.GetMask("Ground");

        //Debug.Log("Current movement state: moving!");

        //change animation
        _sm.animator.SetBool("isRunning", true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Quaternion tiltRot = Quaternion.AngleAxis(50f, _sm.transform.right);
        Vector3 titledDir = tiltRot * _sm.transform.forward;

        if (Physics.Raycast(_sm.transform.position, titledDir, out RaycastHit hit, _maxDistance, _maskToHit))
        {
            //Debug.DrawRay(_sm.transform.position, titledDir);
            //Debug.Log("something was hit!");
            _isHittingGround = true;
        }
        else _isHittingGround = false;

        Look();
        CalculateSpeed();
        Move();
    }

    /// <summary>
    /// determine character's rotation
    /// </summary>
    private void Look()
    {
        if (_sm._inputXZ == Vector3.zero) return;

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(_sm._inputXZ);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        _sm.transform.rotation = Quaternion.RotateTowards(_sm.transform.rotation, rotation, _sm._rotationSpeed * Time.fixedDeltaTime);
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

        if (_isHittingGround)
        {
            Vector3 moveDirection = _sm.transform.forward * _sm._currentSpeed * _sm._inputXZ.magnitude * Time.deltaTime + _sm._velocity;

            _sm._characterController.Move(moveDirection);
        }
    }

    public override void Exit()
    {
        base.Exit();

        _sm.canDash = true;
    }
}
