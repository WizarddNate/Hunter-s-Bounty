using UnityEngine;

public class PlayerIdle : BaseState
{
    private MovementSM _sm;

    public PlayerIdle(MovementSM stateMachine) : base("Idle", stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //move input = 0
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //transition to "moving" state if input != 0
        if (1 + 1 == 2)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }

    }
}
