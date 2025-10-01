using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage;


    //detect collison from hitbox.
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Object hit!");
        if (other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent))
        {
            //Debug.Log("Enemy hit!");
            enemyComponent.TakeDamage(meleeDamage);
            //MeleeAttackEnemy();
        }
    }
}
