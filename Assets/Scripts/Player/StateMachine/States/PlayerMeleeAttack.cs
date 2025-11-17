using System;
using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class PlayerMeleeAttack : BaseState
{
    private float _nextFireTime;
    int _attackNum = 0;
    float _lastClickTime;
    float _maxComboDelay = 0.5f;

    [SerializeField] protected CooldownTimer Combo1CooldownTimer;
    [SerializeField] protected CooldownTimer Combo2CooldownTimer;

    private ActionsSM _sm;
    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        Debug.Log("Current action state: melee attack!");
        _attackNum++;
        Debug.Log(_attackNum);

        _sm.animator.SetBool("Attack1", true);

        Combo1CooldownTimer.StartCooldown();

        /*

        numClicks = Mathf.Clamp(numClicks, 0, 3);

        if (numClicks >= 2 && _sm.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _sm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            _sm.animator.SetBool("Attack1", false);
            _sm.animator.SetBool("Attack2", true);
        }

        if (numClicks >= 3 && _sm.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _sm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            _sm.animator.SetBool("Attack2", false);
            _sm.animator.SetBool("Attack3", true);
            numClicks = 0;
        } */

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Combo1CooldownTimer.CoolDownComplete)
        {
            Debug.Log("Cooldown 1 Complete!");
        }

        if (Combo2CooldownTimer.CoolDownComplete)
        {
            Debug.Log("Cooldown 2 Complete!");
        }
        //if animations are over, reset combo. Without this, attack animations will be infinitly called
        /*
        if(_sm.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _sm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            _sm.animator.SetBool("Attack1", false);
        }
        if (_sm.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _sm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            _sm.animator.SetBool("Attack2", false);
        }
        if (_sm.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _sm.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            _sm.animator.SetBool("Attack3", false);
            numClicks = 0;
        }

        if(Time.time - _lastClickTime > _maxComboDelay)
        /*if (Time.time < startTime + attackTime)
        {
            _sm.meleeWeaponCol.enabled = true;

            return;
        } */

        stateMachine.ChangeState(((ActionsSM)stateMachine).idleActionState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    void Attack()
    {
        
    }

    public override void Exit()
    {
        base.Exit();

        _attackNum = 0;
        _sm.animator.SetBool("Attack1", false);
        _sm.animator.SetBool("Attack2", false);
        _sm.animator.SetBool("Attack3", false);

        Debug.Log("Exiting attack state");


        _sm.meleeWeaponCol.enabled = false;
    }
}