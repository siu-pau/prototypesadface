using UnityEngine;

public class DragAndDropToy : MonoBehaviour
{
    bool dragging = false;

    // Reference to the child GameObject you want to disable while dragging
    public GameObject conveyorCheckChild;

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

                // Disable the child while dragging
                if (conveyorCheckChild != null)
                    conveyorCheckChild.SetActive(false);
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

            // Re-enable the child when dragging stops
            if (conveyorCheckChild != null)
                conveyorCheckChild.SetActive(true);
        }
    }
}