using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Patrolling : BaseState
{

    public Transform transform;
    public NavMeshAgent agent;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointIsSet;
    public LayerMask whatIsGround;

    public override void Enter()
    {
        base.Enter();

        //Debug.Log("enemy is searching for player");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (!walkPointIsSet) SearchWalkPoint();

        //set walk point 
        if (walkPointIsSet)
            agent.SetDestination(walkPoint);


        //walk
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached!
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointIsSet = false;
    }

    private void SearchPlayerPosition()
    {
        //eventually, I'd like for enemies to search for the last place they saw the player at
        return;
    }

    private void SearchWalkPoint()
    {

        //Calculate random point in range
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Debug.Log(walkPoint);

        //make sure the random point is actually on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointIsSet = true;
        else
            SearchWalkPoint();

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
