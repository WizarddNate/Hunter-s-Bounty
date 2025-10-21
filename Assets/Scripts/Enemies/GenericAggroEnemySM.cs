using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class GenericAggroEnemySM : StateMachine
{

    //public Animator animator;
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer;

    

    [Header("Health")]
    public int maxhealth;
    public int health;
    bool isDying;

    [Header("State Control")]
    [SerializeField] string currentStateDisplay;
    public float sightRange;
    public float attackRange;
    bool playerInSightRange, playerInAttackRange;

    //States 
    public Patrolling patrollingState;
    public Chasing chasingState;
    public Attacking attackingState;
    public TakingDamage takingDamageState;

    /* [Header("Damage")]
    public int damage;
    public PlayerHealth playerHealth;
    public GameObject bulletSpawnPoint;
    public GameObject bullet; */

    /*[Header("Dropping Objects")]
    public float dropRange;
    public GameObject essence;
    public int minDropRate;
    public int maxDropRate; */

    private float prevSpeed;

    private void Awake()
    {
        //get player
        player = GameObject.FindWithTag("Player").transform;
        //playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        //get nav mesh
        agent = GetComponent<NavMeshAgent>();
        prevSpeed = agent.speed;

        //get states
        patrollingState.Init(nameof(patrollingState), this);
        chasingState.Init(nameof(chasingState), this);
        attackingState.Init(nameof(attackingState), this);
        takingDamageState.Init(nameof(takingDamageState), this);

        //TakeDamage();
    }

    public void Start()
    {
        //animator = gameObject.GetComponentInChildren<Animator>();
        health = maxhealth;
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
            currentStateDisplay = currentState.ToString();
        }
        else
        {
            currentState = patrollingState; // fail safe to keep state from being null
        }

        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //and attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //state handler
        if (!playerInSightRange && !playerInAttackRange)
        {
            ChangeState(patrollingState);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChangeState(chasingState);
        }
        if (playerInAttackRange && playerInSightRange)
        {
            ChangeState(attackingState);
        }
    }

    protected override BaseState GetInitialState()
    {
        return patrollingState;
    }

    public void TakeDamage()
    {
        ChangeState(takingDamageState);
    }
}
