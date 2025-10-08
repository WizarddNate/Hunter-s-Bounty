using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// will contain ALL variables from old animation and movement scripts
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class MovementSM : StateMachine
{

    //states
    [HideInInspector]
    public PlayerIdle idleState;
    public PlayerMoving movingState;

    //rigidbody here
    public CharacterController _characterController;

    //speed vars, etc
    [Header("Basic Movement")]
    public float maxSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _gravity = -9.81f;
    public float _currentSpeed { get; private set; }
    private Vector3 _velocity;

    [Header("Accelleration")]
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _deceleration = 10f;

    //input
    [Header("Input")]
    public InputActionAsset inputActions;
    private Vector3 _input;
    private Vector2 _getInput;
    private InputAction _moveInput;
    private InputAction _dashInput;

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
        idleState.Init( nameof(idleState),this);
        movingState.Init(nameof(idleState), this);

        //char controller
        _characterController = GetComponent<CharacterController>();

        //input
        _moveInput = InputSystem.actions.FindAction("Move");
        _dashInput = InputSystem.actions.FindAction("Sprint");
    }

    //all of this may need to be moved to the player moving state:

    void FixedUpdate()
    {
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
        //CalculateSpeed();
        //Move();
    }

    /// <summary>
    /// input manager business
    /// </summary>
    private void GatherInput()
    {
        _getInput = _moveInput.ReadValue<Vector2>();
        _input = new Vector3(_getInput.x, 0, _getInput.y);
    }

    /// <summary>
    /// determine character's rotation
    /// </summary>
    private void Look()
    {
        if (_input == Vector3.zero) return;

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(_input);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
