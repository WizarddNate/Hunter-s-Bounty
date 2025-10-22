using System;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class PlayerMeleeAttack : BaseState
{
    float startTime;
    float attackTime = 0.4f;

    private ActionsSM _sm;
    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        Debug.Log("Current action state: melee attack!");
        startTime = Time.time;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Time.time < startTime + attackTime)
        {
            _sm.meleeWeaponCol.enabled = true;

            return;
        }

        stateMachine.ChangeState(((ActionsSM)stateMachine).idleActionState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }


    public override void Exit()
    {
        base.Exit();

        _sm.meleeWeaponCol.enabled = false;
    }
}