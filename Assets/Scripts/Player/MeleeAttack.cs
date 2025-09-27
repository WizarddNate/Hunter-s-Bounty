using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage;


    //detect collison from hitbox.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent))
        {
            enemyComponent.TakeDamage(meleeDamage);
            //MeleeAttackEnemy();
        }
    }
}
