using Unity.VisualScripting;

/// <summary>
/// generic base state, a blueprint for actual states
/// </summary>
public class BaseState
{
    public string name;
    protected StateMachine stateMachine;
    //protected readonly MovementPlayer player;
    //protected readonly Animator animator;

    ////transition time between states
    //protected const crossFadeDuration = 0.1f;

    public BaseState(string name, StateMachine stateMachine) //Animator animator
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter(){}
    public virtual void UpdateLogic(){}
    public virtual void UpdatePhysics(){}
    public virtual void Exit(){}
}
