using System;

[Serializable]
public class BaseAttack1 : BaseState
{
    private ActionsSM _sm;
    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;

        _sm.animator.SetBool("Attack1", true);
    }

    public override void Exit() 
    { 
        base.Exit();

        _sm.animator.SetBool("Attack1", false);
    }
}
