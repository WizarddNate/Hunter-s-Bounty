using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// will contain all variables related to attacking, healing or similar
/// </summary>
public class ActionsSM : StateMachine
{
    //states
    [HideInInspector] public PlayerActionIdle idleActionState;
    [HideInInspector] public PlayerMeleeAttack meleeAttackState;
    [HideInInspector] public PlayerRangedAttack rangedAttackState;

    [Header("Attacking")]
    public GameObject meleeWeapon;
    public GameObject aimPivot;
    [SerializeField] protected CooldownTimer attackCooldownTimer;
    private bool isRanged;
    public bool fire { get; set; }

    [Header("Ranged Attack Bounds")]
    public GameObject aimBoundsSphere;
    public float boundsGrowthSpeed;
    public Vector3 minRange;
    public Vector3 maxRange;
    private Vector3 currentRange;

    [Header("Pickups")]
    public int essenceCount;

    //Inputs
    public InputActionAsset inputActions;

    [HideInInspector] public InputAction _meleeInput;
    [HideInInspector] public InputAction _rangedInput;

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
        //states
        idleActionState.Init(nameof(idleActionState), this);
        meleeAttackState.Init(nameof(meleeAttackState), this);
        //rangedAttackState.Init(nameof(rangedAttackState), this);
        

        //input
        _meleeInput = InputSystem.actions.FindAction("MeleeAttack");
        _rangedInput = InputSystem.actions.FindAction("RangedAttack");
    }

    private void Update()
    {
        aimBoundsSphere.transform.localScale = new Vector3(currentRange.x, transform.localScale.y, currentRange.z);
    }

    protected override BaseState GetInitialState()
    {
        return idleActionState;
    }

}
