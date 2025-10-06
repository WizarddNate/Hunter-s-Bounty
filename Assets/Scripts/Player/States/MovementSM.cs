using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public PlayerIdle idleState;
    public PlayerMoving movingState;

    //rigidbody here
    
    //speed vars, etc

    //animation goes here too i believe 

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        movingState = new PlayerMoving(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
