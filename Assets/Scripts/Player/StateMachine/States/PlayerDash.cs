using System;
using System.Collections;
using System.Xml.Linq;
using UnityEngine;

[Serializable]
public class PlayerDash : BaseState
{
    private MovementSM _sm;
    private CoroutineHost _coroutineHost;
    private GameObject hostObject;
    float startTime;

    public override void Enter()
    {
        base.Enter();
        _sm = (MovementSM)stateMachine;

        Debug.Log("Current movement state: dashing!");

        //create coroutine host
       // GameObject hostObject = new GameObject("CoroutineHost");
        //_coroutineHost = hostObject.AddComponent<CoroutineHost>();

        // dsfasdf
        _sm.canDash = false;
        startTime = Time.time;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        /*if (_sm.canDash)
        {
            _coroutineHost.StartCoroutine(Dashing());
        }*/


        // asdfasdf

        //increase speed
        

        if (Time.time < startTime + _sm.dashDuration)
        {
            Vector3 moveDirection = _sm.transform.forward * _sm.dashSpeed * Time.fixedDeltaTime + _sm._velocity;

            _sm._characterController.Move(moveDirection);// Vector3.forward * 300.0f * Time.fixedDeltaTime);

            return;
        }

        Debug.Log("Finish dash!");

        //return to previous state
        if (_sm._inputXZ != Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
        else if (_sm._inputXZ == Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
        }
    }

    private IEnumerator Dashing()
    {
        Debug.Log("Start Dash!");
        _sm.canDash = false;

        //increase speed
        float startTime = Time.time;

        while (Time.time > startTime + _sm.dashDuration)
        {
            Vector3 moveDirection = _sm.transform.forward * _sm.dashSpeed * _sm._inputXZ.magnitude * Time.fixedDeltaTime + _sm._velocity;

            _sm._characterController.Move(moveDirection);

            yield return null;
        } 
        
        Debug.Log("Finish dash!");

        //return to previous state
        if (_sm._inputXZ != Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).movingState);
        }
        else if (_sm._inputXZ == Vector3.zero)
        {
            stateMachine.ChangeState(((MovementSM)stateMachine).idleState);
        }

        yield break;
    }

    public override void Exit()
    {
        base.Exit();

        if (_coroutineHost != null )
        {
            //destroy courtine host
        }
    }
}

public class CoroutineHost : MonoBehaviour { }

