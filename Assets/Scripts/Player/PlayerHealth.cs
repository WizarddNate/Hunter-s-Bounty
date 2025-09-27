using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public TMP_Text healthText;

    public void Update()
    {
        healthText.SetText("HP: {0}", health);
    }

    public void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {

    }
}
