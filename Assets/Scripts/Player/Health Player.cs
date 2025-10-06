using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPlayer : MonoBehaviour
{
    [Header("Health Functionality")]
    public int maxHealth;
    public int _health { get; private set; }
    private bool isDying;

    [SerializeField] protected CooldownTimer invincibilityTimer;

    [Header("UI")]
    public TMP_Text healthText;

    [Header("Input")]
    private InputAction _heal;
    private InputActionAsset _inputActions;

    private void OnEnable()
    {
        _inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        _inputActions.FindActionMap("Player").Enable();
    }

    void Start()
    {
        isDying = false;
        _health = maxHealth;
    }

    void Update()
    {
        //healthText.SetText("HP: {0}", health);
    }


    public void TakeDamage(int damageAmount)
    {
        //dont take damage if we're dying or if we were hit recently
        if (isDying || !invincibilityTimer.CoolDownComplete) return;

        //invincibility frames
        invincibilityTimer.StartCooldown();

        _health -= damageAmount;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDying = true;
        DeathMenuManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
