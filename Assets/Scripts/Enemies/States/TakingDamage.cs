using UnityEngine;

[SerializeField]
public class TakingDamage : BaseState
{
    StateMachine sm;

    [SerializeField] public GameObject targetGameObject;

    public override void Enter()
    {
        base.Enter();
        if (targetGameObject != null)
        {
            StateMachine component = targetGameObject.GetComponent<StateMachine>();
            if (component != null)
            {
                Debug.Log("Got state machine: " + component);
            }
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
