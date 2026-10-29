using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    public float fallSpeed;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // delete object when falls below screen to stop lag
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }
}
