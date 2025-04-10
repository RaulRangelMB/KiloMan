using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Video guia utilizado para a criação do spawn de inimigos
    // https://www.youtube.com/watch?v=SELTWo1XZ0c

    [SerializeField] private GameObject enemyPrefab;
    private float spawnInterval = 4f;
    private float maxInterval = 8f;
    private float intervalIncrement = 0.5f;
    float minX = -7f;
    float maxX = 7f;
    float minY = -4f;
    float maxY = 4f;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(AdjustSpawnInterval());
    }

    private IEnumerator SpawnEnemies()
    {
        while (!GameController.gameOver)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            EnemyWander enemyScript = enemy.GetComponent<EnemyWander>();
            enemyScript.speed = Random.Range(1f, 5f);
        }
    }

    private IEnumerator AdjustSpawnInterval()
    {
        while (spawnInterval < maxInterval)
        {
            yield return new WaitForSeconds(5f);
            spawnInterval = Mathf.Min(spawnInterval + intervalIncrement, maxInterval);
        }
    }
}
