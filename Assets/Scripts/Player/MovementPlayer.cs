using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
/// <summary>
/// isometric movement for the player
/// </summary>

[RequireComponent(typeof(CharacterController))]
public class MovementPlayer : MonoBehaviour
{
    
    public CharacterController _characterController;

    [Header("Basic Movement")]
    public float maxSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _gravity = -9.81f;
    private float _currentSpeed;
    private Vector3 _velocity;

    [Header("Accelleration")]
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private float _deceleration = 10f;

    [Header("Dashing")]
    public float dashingCooldown = 1.5f;
    public float dashingTime = 0.2f;
    public float dashingSpeed = 7f;
    private bool _canDash;
    private bool _isDashing;

    [Header("Input")] 
    public InputActionAsset inputActions;
    private Vector3 _input;
    private Vector2 _getInput;
    private InputAction _moveInput;
    private InputAction _dashInput;

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
        _characterController = GetComponent<CharacterController>();

        _moveInput = InputSystem.actions.FindAction("Move");
        _dashInput = InputSystem.actions.FindAction("Sprint");
    }

    void Start()
    {
        _canDash = true;
        _isDashing = false;
    }

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
        CalculateSpeed();
        Move();
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
    
    /// <summary>
    /// speed, acceleration and deceleration
    /// </summary>
    private void CalculateSpeed()
    {
        if (_input == Vector3.zero && _currentSpeed > 0)
        {
            _currentSpeed -= _deceleration * Time.fixedDeltaTime;
        }
        else if (_input != Vector3.zero && _currentSpeed < maxSpeed)
        {
            _currentSpeed += _acceleration * Time.fixedDeltaTime;
        }

        _currentSpeed = Mathf.Clamp(_currentSpeed, 0, maxSpeed);
    }

    //apply speed, move foward and dash
    private void Move()
    {
        if (_isDashing)
        {
            _characterController.Move(transform.forward * dashingSpeed * Time.fixedDeltaTime);
            return;
        }

        Vector3 moveDirection = transform.forward * _currentSpeed * _input.magnitude * Time.fixedDeltaTime + _velocity;

        _characterController.Move(moveDirection);
    }
}
