using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointIsSet;

    [Header("Attacking")]
    //public EnemyAttack attack;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [Header("States")]
    public float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [Header("Health")]
    public int health;
    bool isDying;

    [Header("Damage")]
    public int damage;
    private PlayerHealth playerHealth;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = GameObject.FindWithTag("Player").transform.GetComponent<PlayerHealth>();

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //and attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        //this shouldnt happen, but oh well!
        if (!playerInSightRange && playerInAttackRange) Debug.Log("Attack range falsely called");
    }

    private void Patrolling()
    {
        //Debug.Log("Patrolling...");

        if (isDying) return;

        //look for walk point
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

    private void SearchWalkPoint()
    {

        //Calculate random point in range
        float randomX = Random.Range( -walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.z + randomZ);

        //Debug.Log(walkPoint);

        //make sure the random point is actually on the ground
        if (Physics.Raycast(walkPoint, - transform.up, 2f, whatIsGround))
            walkPointIsSet = true;
        else
            SearchWalkPoint();

    }

    private void ChasePlayer()
    {
        //Debug.Log("Chasing...");

        if (isDying) return;

        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Debug.Log("Attacking!");

        if (isDying) return;

        //make sure the enemy doesn't move while attacking
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///
            // ATTACK CODE HREE
            ///

            // deal damage to player
            playerHealth.TakeDamage(damage);

            // do animation


            //register attack and wait before next one can be executed
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    } 

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //DIE!!!!!!!!!!!
        if (health <= 0)
        {
            //play death animation

            //destroy game object
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }   

    private void DestroyEnemy()
    { 
        Destroy(gameObject);
    }
}
