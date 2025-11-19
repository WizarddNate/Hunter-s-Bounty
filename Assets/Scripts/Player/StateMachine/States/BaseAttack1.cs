using System;
using UnityEngine;

[Serializable]
public class BaseAttack1 : BaseState
{
    float _startTime;
    float _attackTime = 0.4f;

    private ActionsSM _sm;

    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        _sm.animator.SetBool("Attack1", true);

        _startTime = Time.time;

        Debug.Log("attack 1!");
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        _sm.animator.SetBool("Attack1", false);

        if (Time.time < _startTime + _attackTime)
        {
            _sm.meleeWeaponCol.enabled = true;

            return;
        } 

        stateMachine.ChangeState(((ActionsSM)stateMachine).idleActionState);
    }

    public override void Exit() 
    { 
        base.Exit();

        _sm.meleeWeaponCol.enabled = false;
    }
}
