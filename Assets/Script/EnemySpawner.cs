using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Rocks Settings")]
    public GameObject[] enemyObjects;
    public float minPosition;
    public float maxPosition;
    public float minEnemySpeed;
    public float maxEnemySpeed;

    [Header("Spawn Timing")]
    public float startSpawnDelay = 1.5f;
    private float spawnDelay;
    private float timer;

    void Start()
    {
        spawnDelay = startSpawnDelay;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // game slowly gets harder, spawn cookies more often
        spawnDelay -= Time.deltaTime * 0.04f;
        if(spawnDelay < 0.4f)
        {
            spawnDelay = 0.4f;
        }

        if (timer >= spawnDelay)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.x = Random.Range(minPosition, maxPosition);

        int targetEnemyIndex = Random.Range(0, enemyObjects.Length);
        GameObject enemyPrefab = enemyObjects[targetEnemyIndex];

        GameObject enemy = Instantiate(enemyPrefab, randomPosition, transform.rotation);

        float randomSpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        EnemyFall enemyFall = enemy.GetComponent<EnemyFall>();
        enemyFall.fallSpeed = randomSpeed;
    }
}
