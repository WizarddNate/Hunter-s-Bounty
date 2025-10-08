using System;
using UnityEngine;

[Serializable]
public class PlayerDash : BaseState
{
    private MovementSM _sm;

    

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }
}
