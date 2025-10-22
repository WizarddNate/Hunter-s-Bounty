using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int meleeDamage;


    //detect collison from hitbox.
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Object hit!");
        if (other.gameObject.TryGetComponent<UniversalEnemyData>(out UniversalEnemyData enemyComponent))
        {
            //Debug.Log("Enemy hit!");
            enemyComponent.TakeDamage(meleeDamage);
            //MeleeAttackEnemy();
        }
    }
}
