using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    private bool checkedPlacement = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkedPlacement) return;

        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Base"))
        {
            CheckOverlap(collision);
            checkedPlacement = true;
        }
    }

    void CheckOverlap(Collision2D collision)
    {
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        BoxCollider2D otherCollider = collision.collider as BoxCollider2D;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float myLeft = myCollider.bounds.min.x; 
        float myRight = myCollider.bounds.max.x;

        float otherLeft = otherCollider.bounds.min.x;
        float otherRight = otherCollider.bounds.max.x;

        float overlap = Mathf.Min(myRight, otherRight) - Mathf.Max(myLeft, otherLeft);
        float requiredOverlap = myCollider.bounds.size.x * 0.5f;

        if (overlap >= requiredOverlap)
        {
            // Valid placement - therefore lock in place 
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            // Bad placement - let it fall completely by physics 
            rb.freezeRotation = false; // allow tipping
        }
    }
}
