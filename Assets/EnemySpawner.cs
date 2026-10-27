using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnCooldown = 2;

    public GameObject enemyObject;

    public float minPosition;
    public float maxPosition;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCooldown)
        {
            timer = 0;
            Object.Instantiate(enemyObject, transform.position, transform.rotation);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = transform.position;
        position.y = Random.Range(minPosition, maxPosition);
        Object.Instantiate(enemyObject, randomPosition, transform.position);
    }
}
