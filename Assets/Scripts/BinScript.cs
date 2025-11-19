using UnityEngine;

public class BinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toy"))
        {
            Transform target = collision.transform;

            // If the toy has a parent, destroy the whole parent object
            if (target.parent != null)
                target = target.parent;

            // Destroy the toy (or parent)
            Destroy(target.gameObject);
        }
    }
}
