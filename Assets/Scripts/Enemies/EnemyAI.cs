using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, IEffectable

{
    Animator animator;
    private SlowdownStatus _data;

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
    public float sightRange;
    public float attackRange;
    bool playerInSightRange, playerInAttackRange;

    [Header("Health")]
    public int maxhealth;
    public int health;
    bool isDying;

    [Header("Damage")]
    public int damage;
    private PlayerHealth playerHealth;

    [Header("Dropping Objects")]
    public float dropRange;
    public GameObject essence;
    public int minDropRate;
    public int maxDropRate;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = GameObject.FindWithTag("Player").transform.GetComponent<PlayerHealth>();

        agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        health = maxhealth;
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
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Debug.Log(walkPoint);

        //make sure the random point is actually on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
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
            animator.SetBool("attacking", true);
            Debug.Log("attack");

            //register attack and wait before next one can be executed
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        animator.SetBool("attacking", false);
        alreadyAttacked = false;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        //DIE!!!!!!!!!!!
        if (health <= 0)
        {
            //play death animation

            //spawn essence
            SpawnEssence();

            //destroy game object
            Invoke(nameof(DestroyEnemy), 0.25f);
        }
    }

    private void SpawnEssence()
    {
        float dropNum = Random.Range(minDropRate, maxDropRate);


        int i = 0;
        while (i < dropNum)
        {

            float _randomX = Random.Range(-dropRange, dropRange);
            float _randomZ = Random.Range(-dropRange, dropRange);

            Instantiate(essence, new Vector3(transform.position.x + _randomX, transform.position.y, transform.position.z + _randomZ), Quaternion.identity);

            i++;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void ApplyEffect(SlowdownStatus _data)
    {
        this._data = _data;
    }

    public void RemoveEffect()
    {
        
    }
}
