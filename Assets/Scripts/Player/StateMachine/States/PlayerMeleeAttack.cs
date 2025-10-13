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

        //attackPointObj = GameObject.Find("MeleeAttackPoint");
        //attackPoint = attackPointObj.GetComponent<Transform>();
        //enemyLayers = LayerMask.GetMask("Enemy");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Attack();
    }

    void Attack()
    {
        _sm.meleeWeapon.SetActive(true);

        //play attack animation

        //detect enemies within range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(_sm.attackPoint.position, _sm.attackRange, _sm.enemyLayers);

        //apply damage to all detected enemies
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("enemy hit: " + enemy.name);
        }

        
        //back to idle
        _sm.meleeWeapon.SetActive(false);

        stateMachine.ChangeState(((ActionsSM)stateMachine).idleActionState);
    }
}