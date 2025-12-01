using UnityEngine;
using UnityEngine.AI;

public class BossSM : StateMachine
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;
    private float _prevSpeed;

    [Header("State Control")]
    [SerializeField] string currentStateDisplay;
    public float sightRange;
    public float attackRange;
    bool playerInSightRange, playerInAttackRange;


    //States 
    public Idle idleState;
    public Patrolling patrollingState;
    public Chasing chasingState;
    public Attacking attackingState;

    public Charging chargingState;
    public Stunned stunnedState;
    public Summoning summoningState;
    public OverheadProjectiles projectileState;

    //public startingBF startingState;
    //public endingBF endingState;
    

    private void Awake()
    {
        //get player
        player = GameObject.FindWithTag("Player").transform;
        //playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        //get nav mesh
        agent = GetComponent<NavMeshAgent>();
        _prevSpeed = agent.speed;

        //get states
        idleState.Init(nameof(idleState), this);
        patrollingState.Init(nameof(patrollingState), this);
        chasingState.Init(nameof(chasingState), this);
        attackingState.Init(nameof(attackingState), this);

        chargingState.Init(nameof(chargingState), this);
        stunnedState.Init(nameof(stunnedState), this);
        summoningState.Init(nameof(summoningState), this);
        projectileState.Init(nameof(projectileState), this);

        //TakeDamage();

    }

    private void Update()
    {
        if (currentState != null)
        {
            currentStateDisplay = currentState.ToString();
        }
        else
        {
            currentState = idleState; // fail safe to keep state from being null
        }
        currentState.UpdateLogic();

        //state controller

        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //and attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

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
        return idleState;
    }
}
