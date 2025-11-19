using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public Vector3 smallScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 largeScale = new Vector3(1f, 1f, 1f);

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("SmallSize"))
        {
            transform.localScale = smallScale;
        }
        else if (other.CompareTag("LargeSize"))
        {
            transform.localScale = largeScale;
        }
    }
}