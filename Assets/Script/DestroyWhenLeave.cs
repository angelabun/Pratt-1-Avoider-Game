using UnityEngine;

public class DestroyWhenLeave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If cookie or candy touches this zone, delete it
        Destroy(other.gameObject);
    }
}