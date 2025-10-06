using UnityEngine;

public class PlayerMoving : BaseState
{
    private MovementSM _sm;
    public PlayerMoving(MovementSM stateMachine) : base("Moving", stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //transition to "idle" state if input = 0
        if (1 + 1 == 4)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        //movement stuff here
    }
}
