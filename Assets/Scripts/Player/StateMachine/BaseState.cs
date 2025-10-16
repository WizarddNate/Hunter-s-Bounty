using Unity.VisualScripting;

/// <summary>
/// generic base state, a blueprint for actual states
/// </summary>
public abstract class BaseState
{
    public string name;
    protected StateMachine stateMachine;

    public void Init(string name, StateMachine stateMachine) //Animator animator
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter(){}
    public virtual void UpdateLogic(){}
    public virtual void UpdatePhysics(){}
    public virtual void Exit(){}
}
