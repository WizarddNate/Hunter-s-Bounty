using System;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class PlayerMeleeAttack : BaseState
{
    private ActionsSM _sm;

    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        Debug.Log("Current action state: melee attack!");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        _sm.meleeWeapon.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        _sm.meleeWeapon.SetActive(false);

        stateMachine.ChangeState(((ActionsSM)stateMachine).idleActionState);
    }
}