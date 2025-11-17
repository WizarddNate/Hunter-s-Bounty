using System;

[Serializable]
public class BaseAttack2 : BaseState
{
    private ActionsSM _sm;
    public override void Enter()
    {
        base.Enter();
        _sm = (ActionsSM)stateMachine;
    }
}
