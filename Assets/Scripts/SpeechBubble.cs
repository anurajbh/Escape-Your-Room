using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public float growthRate = 0.1f;
    public float maxScale = 5f;

    BoxCollider2D bubbleBoxCollider2D;
    private void Start()
    {
        bubbleBoxCollider2D= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        // Increase the size of the speech bubble
        transform.localScale += new Vector3(growthRate, growthRate, 0f) * Time.deltaTime;

        // Check if the mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Check if the ray intersects with the speech bubble's Box Collider 2D
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            // If the ray intersects with the speech bubble, destroy it
            if (hit)
            {
                Destroy(gameObject);
            }
        }

        // Limit the size of the speech bubble
        if (transform.localScale.x >= maxScale || transform.localScale.y >= maxScale)
        {
            Destroy(gameObject);
        }
    }
}
