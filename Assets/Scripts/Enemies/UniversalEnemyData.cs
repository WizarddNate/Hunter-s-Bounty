using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class UniversalEnemyData : MonoBehaviour
{
    [Header("Health")]
    public int maxhealth;
    int health;
    public bool isDying; //var isnt currently being used anywhere, but i have a feeling it will be useful someday

    [Header("Damage UI")]
    public GameObject PopupTextPrefab;
    public float textDistance = 4f;
    public float textSpeed = 1f;

    void Start()
    {
        isDying = false;
        health = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //popup text
        SpawnText(damage.ToString());

        //die
        if (health <= 0)
        {
            isDying = true;
            Destroy(gameObject);
        }
    }

    public void SpawnText(string text)
    {
        GameObject spawnedText = Instantiate(PopupTextPrefab, gameObject.transform);
        //spawnedText.transform.position = Vector3.zero;
        spawnedText.GetComponent<TextDamagePopup>().SetupText(text);
        StartCoroutine(Move(spawnedText));
    }

    //animate the spawned damage text
    public IEnumerator Move(GameObject _textObj)
    {
        float targetY = _textObj.transform.position.y + (textDistance * Random.Range(0.3f, 1.5f));

        while(_textObj.transform.position.y < targetY)
        {
            _textObj.transform.position += Vector3.up * (textSpeed * Random.Range(3f, 5f)) * Time.deltaTime;
            yield return null;
        }
        
        Destroy(_textObj);
    }
}
