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

        _sm.canDash = true; //remove this once dash cooldown is made
        //Debug.Log("Current movement state: idle!");

        //change animation
        _sm.animator.Play("Move");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        //decrease speed if still moving
        if (_sm._inputXZ == Vector3.zero && _sm._currentSpeed > 0) //decellerate
        {
            _sm._currentSpeed -= _sm._deceleration * Time.deltaTime;
        }

        Look();
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

    public override void Exit()
    {
        base.Exit();
    }
}
