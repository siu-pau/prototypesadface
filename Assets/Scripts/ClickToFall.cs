using System;
using UnityEngine;

public class ClickToFall : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // freeze until clicked
        rb.isKinematic = true;
    }

    void OnMouseDown()
    {
        // enable physics so it falls
        rb.isKinematic = false;
    }
}
