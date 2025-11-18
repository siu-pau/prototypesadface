using UnityEngine;

public class RemoveToyOnTrigger2D : MonoBehaviour
{
    public float slideSpeed = 2f;  // movement speed to the right

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toy"))
        {
            Transform target = collision.transform;

            // If the toy is part of a parent, slide the whole parent instead
            if (target.parent != null)
                target = target.parent;

            StartCoroutine(SlideOffScreenAndDestroy(target.gameObject));
        }
    }

    private System.Collections.IEnumerator SlideOffScreenAndDestroy(GameObject target)
    {
        while (target != null)
        {
            // Move the target to the right every frame
            target.transform.Translate(Vector3.right * slideSpeed * Time.deltaTime);

            // Convert position to viewport space
            Vector3 viewPos = Camera.main.WorldToViewportPoint(target.transform.position);

            // If the toy is completely to the right of the screen (x > 1.2)
            // 1.0 = right edge of screen
            // 1.2 = slightly off-screen to fully hide the object
            if (viewPos.x > 1.2f)
            {
                Destroy(target);
                yield break;
            }

            yield return null;
        }
    }
}