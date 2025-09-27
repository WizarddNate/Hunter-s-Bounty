using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float rotationSpeed = 360f;    

    [SerializeField] private float accelerationFactor = 5f;
    [SerializeField] private float decelerationFactor = 10f;

    [Header("Dash")]
    [SerializeField] private float dashingCooldown = 1.5f;
    [SerializeField] private float dashingTime = 0.2f;

    [SerializeField] private float dashingSpeed = 7f;

    private bool _canDash;
    private bool _isDashing;

    private bool _dashInput;

    private float _currentSpeed;
    private InputSystem_Actions _playerInputActions;
    private Vector3 _input;
    private CharacterController _characterController;

    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
        _characterController = GetComponent<CharacterController>();

        _canDash = true;
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Disable();
    }

    private void Update()
    {
        GatherInput();

        Look();
        CalculateSpeed();

        Move();

        if (_dashInput && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        yield return new WaitForSeconds(dashingTime);
        _isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        _canDash = true;
    }

    private void CalculateSpeed()
    {
        if (_input == Vector3.zero && _currentSpeed > 0)
        {
            _currentSpeed -= decelerationFactor * Time.deltaTime;
        }
        else if (_input != Vector3.zero && _currentSpeed < maxSpeed)
        {
            _currentSpeed += accelerationFactor * Time.deltaTime;
        }

        _currentSpeed = Mathf.Clamp(_currentSpeed, 0, maxSpeed);
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
        Vector3 multipliedMatrix = isometricMatrix.MultiplyPoint3x4(_input);

        Quaternion rotation = Quaternion.LookRotation(multipliedMatrix, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        if (_isDashing)
        {
            _characterController.Move(transform.forward * dashingSpeed * Time.deltaTime);
            return;
        }
        
        Vector3 moveDirection = transform.forward * _currentSpeed * _input.magnitude * Time.deltaTime;

        _characterController.Move(moveDirection); 
    }

    private void GatherInput()
    {
        Vector2 input = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _input = new Vector3(input.x, 0, input.y);
        _dashInput = _playerInputActions.Player.Sprint.IsPressed();

        Debug.Log(_input);
    }
}
