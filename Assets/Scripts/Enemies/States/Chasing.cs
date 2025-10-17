using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Chasing : BaseState
{
    public NavMeshAgent agent;
    public Transform player;

    public override void Enter()
    {
        base.Enter();

        player = GameObject.FindWithTag("Player").transform;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        agent.SetDestination(player.position - new Vector3(1, 0, 1));
    }
}
