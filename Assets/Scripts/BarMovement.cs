using UnityEngine;

public class BarMovement : MonoBehaviour
{
    public float speed = 1f; // speed of the bar
    public Transform leftLimit; // left boundary
    public Transform rightLimit; // right boundary 

    public GameObject boxPrefab; // defines the box prefab for use

    private int direction = 1; // 1 = right, -1 = left
    private GameObject currentBox;


    void Start()
    {
        SpawnNewBox();
    }


    void Update()
    {
        MoveBar();
        HandleInput();
    }

    void MoveBar()
    {
        // Moving the bar horizontally:
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime); // Time.deltaTime makes movement smooth, Translate moves the object every frame

        // If we reach the right limit:
        if (transform.position.x >= rightLimit.position.x)
        {
            direction = -1; // move left
        }

        // If we reach the left limit:
        if (transform.position.x <= leftLimit.position.x)
        {
            direction = 1; // move right
        }

    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) && currentBox != null)
        {
            ReleaseBox();
        }
    }

    void SpawnNewBox()
    {
        currentBox = Instantiate(boxPrefab);

        currentBox.transform.parent = transform;

        currentBox.transform.localPosition = new Vector3(0, -1f, 0);

        Rigidbody2D rb = currentBox.GetComponent<Rigidbody2D>(); // access to the rigid body physics assigned to the current box prefab 
        rb.simulated = false; // Disable physics when the box is attached 
    }

    void ReleaseBox()
    {
        currentBox.transform.parent = null; // Detach from the bar

        Rigidbody2D rb = currentBox.GetComponent<Rigidbody2D>(); 
        rb.simulated = true; // Enable physics 

        currentBox = null; // Prepare for the next box spawn

        Invoke("SpawnNewBox", 2.0f); // Spawn new box after half a second
    }

}