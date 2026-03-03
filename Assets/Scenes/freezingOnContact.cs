using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.name == "box")
        {
            Debug.Log("thjk");
            float boxBase = transform.position.x;
            float boxBase2 = collision.transform.position.x;
            Debug.Log($"{boxBase},{boxBase2}");
        }
        else if (collision.gameObject.name == "floor")
        {
            Debug.Log("freese");

        }


    }
}
