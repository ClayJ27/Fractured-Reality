using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public int minEnemiesPerBatch = 3;
    public int maxEnemiesPerBatch = 4;
    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 5f;
    public float spawnRadius = 2f;
 
    

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);

            int enemiesBatchSize = Random.Range(minEnemiesPerBatch, maxEnemiesPerBatch);
            for(int i = 0; i < enemiesBatchSize; i++)
            {
                Vector2 spawnOffset = Random.insideUnitCircle * spawnRadius;
                Vector2 spawnPosition = (Vector2)gameObject.transform.position + spawnOffset;

                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
