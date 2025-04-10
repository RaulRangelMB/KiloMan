using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField] private GameObject coinPrefab;
    private float spawnInterval = 0.5f;
    private float maxInterval = 1.5f;
    private float intervalIncrement = 0.085f;
    float minX = -7f;
    float maxX = 7f;
    float minY = -3.5f;
    float maxY = 3.5f;
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
            
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            GameController.SpawnCollectable();
        }
    }

    private IEnumerator AdjustSpawnInterval()
    {
        while (spawnInterval < maxInterval)
        {
            yield return new WaitForSeconds(2f);
            spawnInterval = Mathf.Min(spawnInterval + intervalIncrement, maxInterval);
        }
    }
}
