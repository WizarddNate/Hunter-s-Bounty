using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject smallEnemyPrefab;
    [SerializeField]
    private GameObject bigEnemyPrefab;

    [SerializeField]
    private float smallEInterval = 5.5f;
    [SerializeField]
    private float bigEInterval = 8.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy(smallEInterval, smallEnemyPrefab));
        StartCoroutine(SpawnEnemy(bigEInterval, bigEnemyPrefab));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5, 5f)), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }
}
