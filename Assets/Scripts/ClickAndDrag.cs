using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool dragging = false;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // When mouse is pressed, check if THIS object was clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit && hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                dragging = true;
            }
        }

        // Dragging movement
        if (dragging)
        {
            transform.position = mousePos;
        }

        // Stop dragging when mouse is released
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
}