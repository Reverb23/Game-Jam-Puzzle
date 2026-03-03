using UnityEngine;

public class BarMovement : MonoBehaviour
{
    public float speed = 5f; // speed of the bar
    public Transform leftLimit; // left boundary
    public Transform rightLimit; // right boundary 

    private int direction = 1; // 1 = right, -1 = left

    // Update is called once per frame
    void Update()
    {
        // Moving the bar horizontally 
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime); // Time.deltaTime makes movement smooth, Translate moves the object every frame

        // If we reach/pass the right limit
        if (transform.position.x >= rightLimit.position.x)
        {
            direction = -1; // Start moving left
        }

        // If we reach/pass the left limit 
        if (transform.position.x <= leftLimit.position.x) { 
            direction = 1; // Start moving right
        }
    }
}

// NOTES:
// 1 means move right 
// -1 means move left 