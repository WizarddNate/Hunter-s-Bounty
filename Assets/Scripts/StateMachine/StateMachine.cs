using UnityEngine;

/// <summary>
/// this state machine script is generic enough to handle transitions/updates for ALL state machines.
/// </summary>
public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    private void Start()
    {
        currentState = GetInitialState();

        //enter current state
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();

            //test string
            //string content = currentState != null ? currentState.name : "(no current state!)";
            //Debug.Log("Current state: " + content);
        }
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;

        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}
