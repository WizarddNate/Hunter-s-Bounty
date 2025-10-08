using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// will contain all variables related to attacking, healing or similar
/// </summary>
public class ActionsSM : StateMachine
{
    //states
    [HideInInspector] public PlayerIdle idleState;

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
        idleState.Init(nameof(idleState), this);

        //input

    }

    private void Update()
    {
        aimBoundsSphere.transform.localScale = new Vector3(currentRange.x, transform.localScale.y, currentRange.z);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

}
