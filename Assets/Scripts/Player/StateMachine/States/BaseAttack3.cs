using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public class BaseAttack3 : BaseState
{
    float _startTime;
    float _attackTime = 0.4f;

    private ActionsSM _sm;
    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        _sm.animator.SetBool("Attack3", true);

        _startTime = Time.time;

        Debug.Log("attack 3!");

        _sm.weapon.GetComponent<MeleeWeapon>().meleeDamage += 5;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        _sm.animator.SetBool("Attack3", false);

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

        _sm.weapon.GetComponent<MeleeWeapon>().meleeDamage -= 5;

        _sm.meleeWeaponCol.enabled = false;
    }
}