using UnityEngine;

public class Bbullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody rb;
    public PlayerHealth playerHealth;
    public int damage;
    public int timer;

    void Awake()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        Destroy(gameObject, timer);



        //rb.AddForce(transform.position * bulletSpeed, ForceMode.Impulse); // Set initial velocity
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
