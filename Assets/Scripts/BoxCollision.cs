using UnityEngine; // access to unity's core features like Rigidbody2D

public class BoxCollision : MonoBehaviour
{

    public GameObject snapEffect;

    private bool checkedPlacement = false; // prevents placement logic to keep running, can only be checked once 

    // automatically runs when object first collides with another object 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkedPlacement) return; // if already checked placement, return 

        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Base")) // only run stacking logic if we hit another box or the base platform
        {
            CheckOverlap(collision); // call function to measure horizontal overlap
            checkedPlacement = true; // mark current box as checked so we do not recheck it 
        }
    }

    void CheckOverlap(Collision2D collision) // calculates if placement of box is correct 
    {
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>(); // get this current box's collider
        BoxCollider2D otherCollider = collision.collider as BoxCollider2D; // get the collider of the box we hit 
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // get this current box's Rigidbody so we can control its physics

        // get the world-space left and right edges of this box
        float myLeft = myCollider.bounds.min.x;  
        float myRight = myCollider.bounds.max.x;

        // get the world-space left and right edges of the box/base below the current box 
        float otherLeft = otherCollider.bounds.min.x;
        float otherRight = otherCollider.bounds.max.x;

        // calculate how much the two boxes overlap horizontally 
        float overlap = Mathf.Min(myRight, otherRight) - Mathf.Max(myLeft, otherLeft);

        // calculate 50% of the current box's width = minimum overlap required for valid placement 
        float requiredOverlap = myCollider.bounds.size.x * 0.5f;


        if (overlap >= requiredOverlap)
        {
            // If at least half of the box is supported:
            rb.linearVelocity = Vector2.zero; // stop all movement 
            rb.angularVelocity = 0f; // stop any rotation 
            rb.bodyType = RigidbodyType2D.Static; // convert the box to static

            // Snap this bos's x-position to the box below:
            Vector3 newPos = transform.position;
            newPos.x = Mathf.Clamp(transform.position.x, otherLeft + myCollider.bounds.size.x / 2, otherRight - myCollider.bounds.size.x / 2);
            transform.position = newPos;

            // play particle effect at this box's  position 
            if (snapEffect != null)
            {
                GameObject effect = Instantiate(snapEffect, transform.position, Quaternion.identity);
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                if (ps != null) ps.Play();
            }
        }

        else
        {
            // If less than half is supported:

            rb.freezeRotation = false; // allow box to rotate and gravity + physics will cause it to fall and tip 
        }
    }
}
