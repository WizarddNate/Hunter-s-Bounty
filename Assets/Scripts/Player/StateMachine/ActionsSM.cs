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
    [HideInInspector] public PlayerMeleeAttack meleeAttackState;

    public BaseAttack1 BAttack1State;
    public BaseAttack2 BAttack2State;
    public BaseAttack3 BAttack3State;

    [Header("Attacking")]
    public GameObject weapon;
    public Collider meleeWeaponCol;
    [SerializeField]int _attackNum;
    [SerializeField] protected CooldownTimer attack1CooldownTimer;
    [SerializeField] protected CooldownTimer attack2ComboTimer;
    [SerializeField] protected CooldownTimer attack3ComboTimer;
    public bool fire { get; set; }
    public LayerMask enemyLayers;


    [Header("Pickups")]
    public int essenceCount;

    //Inputs
    public InputActionAsset inputActions;

    [HideInInspector] public InputAction _meleeInput;

    private bool tryAttack = false;

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

        BAttack1State.Init(nameof(BAttack1State), this);
        BAttack2State.Init(nameof(BAttack2State), this);
        BAttack3State.Init(nameof(BAttack3State), this);

        //input
        _meleeInput = InputSystem.actions.FindAction("MeleeAttack");
        _meleeInput.performed += Attack;
    }
      
    public void Start()
    {
        weapon = GameObject.FindWithTag("Weapon");
        meleeWeaponCol.enabled = false;

        _attackNum = 0;
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

        if (attack3ComboTimer.CoolDownComplete && attack2ComboTimer.CoolDownComplete && attack1CooldownTimer.CoolDownComplete && tryAttack)
        {
            _attackNum = 1;
            attack1CooldownTimer.StartCooldown();
            attack2ComboTimer.StartCooldown();

            Debug.Log("Attack");

            ChangeState(BAttack1State);

            tryAttack  = false;

            return;
        }
        else if (attack1CooldownTimer.CoolDownComplete && !attack2ComboTimer.CoolDownComplete && tryAttack && currentState != BAttack2State)
        {
            attack3ComboTimer.StartCooldown();

            _attackNum = 2;
            ChangeState(BAttack2State);
            tryAttack = false;

            return;
        }
        else if (attack1CooldownTimer.CoolDownComplete && attack2ComboTimer.CoolDownComplete && !attack3ComboTimer.CoolDownComplete && tryAttack && currentState != BAttack3State)
        {
            _attackNum = 0;
            ChangeState(BAttack3State);
            tryAttack = false;

            return;
        }

        if (attack1CooldownTimer.CoolDownComplete && attack2ComboTimer.CoolDownComplete && attack3ComboTimer.CoolDownComplete)
        {
            _attackNum = 0;
        } 
    }

    void Attack(InputAction.CallbackContext context)
    {
        tryAttack = true;
    }

    protected override BaseState GetInitialState()
    {
        return idleActionState;
    }

}
