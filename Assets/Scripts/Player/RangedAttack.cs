using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] public PlayerController controller;
    public int rangedDamage;
    public Collider col;

    private void Update()
    {
        
        if (controller.fire)
        {
            Debug.Log("Fire!!");
            if (col.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent))
            {
                Debug.Log("Target hit!!");
                controller.fire = false;
                enemyComponent.TakeDamage(rangedDamage);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Entered");
        //if (controller.fire)
        //{
        //    Debug.Log("Fire!!");
        //    if (other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent))
        //    {
        //        Debug.Log("Target hit!!");
        //        controller.fire = false;
        //        enemyComponent.TakeDamage(rangedDamage);
        //    }
        //}
    }
}
