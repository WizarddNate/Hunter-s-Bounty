using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerHealth : MonoBehaviour
{
    [Header("Health vars")]
    public float health { get; set; }
    public float maxHealth;
    //public float damageCooldown;
    private bool isDying;

    [SerializeField] protected CooldownTimer invincibilityTimer;

    [Header("UI")]
    [SerializeField] private PlayerHPBar _healthBar;
    public GameObject PopupTextPrefab;
    public float textDistance = 4f;
    public float textSpeed = 1f;
    public GameObject deathMenu;
    private DeathScreen _deathMenuScript;

    [Header("Animation")]
    MeshRenderer meshRenderer;
    Color originColor;
    float flashTime = 0.15f;


    //healing spell stuff will be put in the ACTIONS state machine
    /*
    [Header("Heal Spell")]
    public PlayerController playerController;
    private int healAmount = 1;
    private float healDuration = 5f;
    private float healCooldown = 1.5f;
    private int essenceNeeded = 5;
    private bool _canHeal;
    private bool _isHealing;
    //private InputAction heal; */

    public InputActionAsset inputActions;
    //[HideInInspector] public InputAction _healInput;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();

        //heal = _playerInputActions.Player.HealSpell;
        //heal.Enable();
        //heal.performed += healInput;
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    public void Update()
    {
        //healthText.SetText("HP: {0}", health);
    }

    public void Start()
    {
        isDying = false;
        health = maxHealth;

        _healthBar.UpdateHealthbar(maxHealth, health);
        deathMenu.SetActive(false);

        _deathMenuScript = deathMenu.GetComponent<DeathScreen>();

    }
    public void TakeDamage(int damageAmount)
    {
        //dont take damage if we're dying or if we were hit recently
        if (isDying || !invincibilityTimer.CoolDownComplete) return;

        invincibilityTimer.StartCooldown();

        health -= damageAmount;

        //popup text?
        SpawnText(damageAmount.ToString());

        //hp bar
        _healthBar.UpdateHealthbar(maxHealth, health);
        
        //die
        if (health <= 0)
        {
            Die();
        }
    }

    public void SpawnText(string text)
    {
        GameObject spawnedText = Instantiate(PopupTextPrefab, gameObject.transform);
        spawnedText.transform.position = Vector3.zero;
        spawnedText.GetComponent<TextDamagePopup>().SetupText(text);
        StartCoroutine(Move(spawnedText));
    }

    //animate the spawned damage text
    public IEnumerator Move(GameObject _textObj)
    {
        float targetY = _textObj.transform.position.y + (textDistance * Random.Range(0.3f, 1.5f));

        while (_textObj.transform.position.y < targetY)
        {
            _textObj.transform.position += Vector3.up * (textSpeed * Random.Range(3f, 5f)) * Time.deltaTime;
            yield return null;
        }

        Destroy(_textObj);
    }

    public void Die()
    {
        isDying = true;

        deathMenu.SetActive(true);
        _deathMenuScript.SetFinalTime();


        Debug.Log("dead");
        //DeathMenuManager.instance.GameOver();
        //gameObject.SetActive(false);
    }

    /*
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
        if (playerController.essenceCount > essenceNeeded)
        {
            StartCoroutine(HealSpell());
        }
    }
    
    */
    

}
