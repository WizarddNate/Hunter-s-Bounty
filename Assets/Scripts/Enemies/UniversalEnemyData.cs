using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class UniversalEnemyData : MonoBehaviour
{
    [Header("Health")]
    public int maxhealth;
    int _health;
    public bool isDying; //var isnt currently being used anywhere, but i have a feeling it will be useful someday

    [Header("Damage UI")]
    public GameObject PopupTextPrefab;
    public float textDistance = 4f;
    public float textSpeed = 1f;

    [Header("Knockback and Stun")]
    public float knockbackForce = 100f;
    public float _knockbackDuration = 0.8f;
    private bool _isKnockedBack;

    [Header("Essence Spawn")]
    public int minDropRate;
    public int maxDropRate;
    public float dropRange; //distance from enemy in which the prefab will spawn
    public GameObject essence;

    private Rigidbody rb;
    private NavMeshAgent agent;
    private float navAgentPrevSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        isDying = false;
        _isKnockedBack = false;

        _health = maxhealth;
        navAgentPrevSpeed = agent.speed;
    }

    public void TakeDamage(int damage, Vector3 knockbackDirection)
    {
        _health -= damage;

        //popup text
        SpawnText(damage.ToString());

        //ApplyKnockback(knockbackDirection);

        //die
        if (_health <= 0)
        {
            SpawnEssence();

            Invoke(nameof(Die), 0.25f);
        }
    }

    //spawn popup text when damaged
    public void SpawnText(string text)
    {
        GameObject spawnedText = Instantiate(PopupTextPrefab, gameObject.transform);
        //spawnedText.transform.position = Vector3.zero;
        spawnedText.GetComponent<TextDamagePopup>().SetupText(text);
        StartCoroutine(TextMove(spawnedText));
    }

    //animate the spawned damage text
    public IEnumerator TextMove(GameObject _textObj)
    {
        float targetY = _textObj.transform.position.y + (textDistance * Random.Range(0.3f, 1.5f));

        while(_textObj.transform.position.y < targetY)
        {
            _textObj.transform.position += Vector3.up * (textSpeed * Random.Range(3f, 5f)) * Time.deltaTime;
            yield return null;
        }
        
        Destroy(_textObj);
    }

    //knockback enemy
    public void ApplyKnockback(Vector3 knockbackDirection)
    {
        _isKnockedBack = true;
        agent.speed = 0;

        
        Vector3 direction = knockbackDirection.normalized;
        

        //rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        Vector3 _warpDirection = direction * knockbackForce;
        agent.Warp(_warpDirection);
        Debug.Log("Direction: " + _warpDirection);

        agent.ResetPath();
        
        Invoke(nameof(ResetKnockback), _knockbackDuration);
    }

    void ResetKnockback()
    {
        _isKnockedBack = false;
        //rb.linearVelocity = Vector3.zero;
        agent.speed = navAgentPrevSpeed;
    }


    private void SpawnEssence()
    {
        float dropNum = Random.Range(minDropRate, maxDropRate);

        int i = 0;
        while (i < dropNum)
        {
            if (essence == null){
                Debug.Log("Essence prefab is missing!");
            }

            float _randomX = Random.Range(-dropRange, dropRange);
            float _randomZ = Random.Range(-dropRange, dropRange);

            Instantiate(essence, new Vector3(transform.position.x + _randomX, transform.position.y, transform.position.z + _randomZ), Quaternion.identity);

            i++;
        }
    }

    //DIE
    void Die()
    {
        isDying = true;
        Destroy(gameObject);


    }
}
