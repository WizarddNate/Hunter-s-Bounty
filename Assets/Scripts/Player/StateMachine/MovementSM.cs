using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// will contain ALL variables movement states
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class MovementSM : StateMachine
{
    StateMachine _sm;
    public string currentString;

    //states
    [HideInInspector] public PlayerIdle idleState;
    [HideInInspector] public PlayerMoving movingState;
    [HideInInspector] public PlayerDash dashState;

    //rigidbody here
    public CharacterController _characterController;

    //speed vars, etc
    [Header("Basic Movement")]
    public float maxSpeed = 10f;
    [SerializeField] public float _rotationSpeed = 180f;
    [SerializeField] public float _gravity = -9.81f;
    [HideInInspector] public float _currentSpeed;
    [HideInInspector] public Vector3 _velocity;
    [SerializeField] public float _acceleration = 5f;
    [SerializeField] public float _deceleration = 10f;

    [Header("Dashing")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.8f;
    public float dashCooldown = 0.5f;
    [HideInInspector] public bool isDashing;
    [HideInInspector] public bool canDash = true;

    //input
    [Header("Input")]
    public InputActionAsset inputActions;

    [HideInInspector]public Vector3 _inputXZ;
    [HideInInspector] public Vector2 _getInput;
    [HideInInspector] public InputAction _moveInput;
    [HideInInspector] public InputAction _dashInput;


    //animation goes here too i believe 

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
        idleState.Init(nameof(idleState),this);
        movingState.Init(nameof(movingState), this);
        dashState.Init(nameof(dashState), this);

        //char controller
        _characterController = GetComponent<CharacterController>();

        //input
        _moveInput = InputSystem.actions.FindAction("Move");
        _dashInput = InputSystem.actions.FindAction("Dash");
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }

        //show current state in inspector
        currentString = currentState.ToString();
    }

    void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }

        bool isGrounded = _characterController.isGrounded;

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }

        if (!isGrounded)
        {
            _velocity.y = _gravity * Time.fixedDeltaTime;
        }

        GatherInput();
        Look();
    } 
    
    /// <summary>
    /// input manager business
    /// </summary>
    private void GatherInput()
    {
        _getInput = _moveInput.ReadValue<Vector2>();
        _inputXZ = new Vector3(_getInput.x, 0, _getInput.y);
    }

    /// <summary>
    /// determine character's rotation
    /// </summary>
    private void Look()
    {
        if (_inputXZ == Vector3.zero) return;

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(_inputXZ);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
