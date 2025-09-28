using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health vars")]
    public int health { get; set; }
    public int maxHealth;
    //public float damageCooldown;
    private bool isDying;

    [SerializeField] protected CooldownTimer invincibilityTimer;

    [Header("UI")]
    public TMP_Text healthText;

    [Header("Animation")]
    MeshRenderer meshRenderer;
    Color originColor;
    float flashTime = 0.15f;

    [Header("Heal Spell")]
    public PlayerController playerController;
    private int healAmount = 1;
    private float healDuration = 5f;
    private float healCooldown = 1.5f;
    private int essenceMin = 5;
    private bool _canHeal;
    private bool _isHealing;
    private InputAction heal;

    private InputSystem_Actions _playerInputActions;

    private void OnEnable()
    {
        _playerInputActions.Player.Enable();

        heal = _playerInputActions.Player.HealSpell;
        heal.Enable();
        //heal.performed += healInput;
    }

    private void OnDisable()
    {

    }

    public void Update()
    {
        healthText.SetText("HP: {0}", health);
    }

    public void Start()
    {
        isDying = false;
        health = maxHealth;

        //flash animation
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originColor = meshRenderer.material.color;
    }
    public void TakeDamage(int damageAmount)
    {
        //dont take damage if we're dying or if we were hit recently
        if (isDying || !invincibilityTimer.CoolDownComplete) return;

        invincibilityTimer.StartCooldown();

        FlashStart();
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    /*    private void Awake()
        {
            _playerInputActions = new InputSystem_Actions();
            _characterController = GetComponent<CharacterController>();
        } */

    void FlashStart()
    {
        meshRenderer.material.color = Color.red;
        Invoke("FlashEnd", flashTime);
    }

    void FlashEnd()
    {
        meshRenderer.material.color = originColor;
    }

    public void Die()
    {
        isDying = true;
        DeathMenuManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    private IEnumerator HealSpell()
    {
        _canHeal = false;
        _isHealing = true;
        yield return new WaitForSeconds(healDuration);
        health += healAmount;

        //    _isHealing = false;
        yield return new WaitForSeconds(healCooldown);
        _canHeal = true;
    }

    public void healInput()
    {
        if (playerController.essenceCount > essenceMin)
        {
            StartCoroutine(HealSpell());
        }
    }
    
    

}
