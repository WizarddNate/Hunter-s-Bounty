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
            //knockback position
            Vector3 knockbackDirection = transform.position - other.transform.position;

            //Apply damage
            enemyComponent.TakeDamage(meleeDamage, knockbackDirection);


        }
    }
}
