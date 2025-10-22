using System.Runtime.CompilerServices;
using UnityEngine;

public class UniversalEnemyData : MonoBehaviour
{
    [Header("Health")]
    public int maxhealth;
    int health;
    bool isDying;

    void Start()
    {
        health = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
