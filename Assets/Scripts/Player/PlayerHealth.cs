using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health vars")]
    public int health {get; set;}
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
    }

}
