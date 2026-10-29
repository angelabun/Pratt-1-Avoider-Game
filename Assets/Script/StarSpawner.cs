using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject smallCandyPrefab;
    public GameObject bigCandyPrefab;
    public float starSpawnDelay = 3f;
    public float minX;
    public float maxX;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= starSpawnDelay)
        {
            SpawnStar();
            timer = 0;
        }
    }

    void SpawnStar()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(minX, maxX);

        GameObject pickCandy;
        if(Random.value > 0.5f)
        {
            pickCandy = bigCandyPrefab;
        }
        else
        {
            pickCandy = smallCandyPrefab;
        }

        GameObject newStar = Instantiate(pickCandy, pos, transform.rotation);
        EnemyFall fall = newStar.GetComponent<EnemyFall>();
        fall.fallSpeed = 2.5f;
    }
}
