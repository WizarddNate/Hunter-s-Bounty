using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// will contain all variables related to attacking, healing or similar
/// </summary>
public class ActionsSM : StateMachine
{
    public Animator animator;

    [Header("State Control")]
    [SerializeField] string currentStateDisplay;
    [HideInInspector] public PlayerActionIdle idleActionState;
    public PlayerMeleeAttack meleeAttackState;

    [Header("Attacking")]
    public Collider meleeWeaponCol;
    [SerializeField] protected CooldownTimer attackCooldownTimer;
    public bool fire { get; set; }
    public Transform attackPoint;
    public LayerMask enemyLayers;


    [Header("Pickups")]
    public int essenceCount;

    //Inputs
    public InputActionAsset inputActions;

    [HideInInspector] public InputAction _meleeInput;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        //get animatior
        animator = GetComponentInChildren<Animator>();

        //states
        idleActionState.Init(nameof(idleActionState), this);
        meleeAttackState.Init(nameof(meleeAttackState), this);
        //rangedAttackState.Init(nameof(rangedAttackState), this);
        

        //input
        _meleeInput = InputSystem.actions.FindAction("MeleeAttack");
    }
      
    public void Start()
    {
        meleeWeaponCol.enabled = false;
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
            currentState = idleActionState; // fail safe to keep state from being null
        }

        //state handler
        if (_meleeInput.IsPressed() && attackCooldownTimer.CoolDownComplete)
        {
            attackCooldownTimer.StartCooldown();
            ChangeState(meleeAttackState);
        }
    }

    protected override BaseState GetInitialState()
    {
        return idleActionState;
    }

}
