using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRangedAttack : BaseState
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

    public override void Exit()
    {
        base.Exit();
    }
}
