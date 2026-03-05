using UnityEngine;

public class FallDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered trigger");

        if (collision.CompareTag("Box"))
        {
            Debug.Log("Box detected");

            GameManager.instance.BlockFell();

            collision.tag = "Untagged";
        }
    }
}