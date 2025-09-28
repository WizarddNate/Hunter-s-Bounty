using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] public PlayerController controller;
    [SerializeField] public GameObject parentAimer;
    public int rangedDamage;
    public Collider col;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (controller.fire)
        {
            Debug.Log("Fire!!");
            //other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent)
            if (other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemyComponent))
            {
                Debug.Log("Target hit!!");
                controller.fire = false;
                enemyComponent.TakeDamage(rangedDamage);
                parentAimer.SetActive(false);
            }
            else
            {
                Debug.Log("Target miss");
                controller.fire = false;
                parentAimer.SetActive(false);
            }
        }
    }
}
