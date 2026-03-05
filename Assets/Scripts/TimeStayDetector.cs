using UnityEngine;
using UnityEngine.SceneManagement;
public class WinZone : MonoBehaviour
{
    public float requiredStayTime = 2f; // Time stack must stay above height
    private float stayTime = 0f;
    private bool boxInside = false;
    public string LoseUI; // Name of the lose scene to load
    void Update()
    {
        if (boxInside)
        {
            stayTime += Time.deltaTime;

            if (stayTime >= requiredStayTime)
            {
                WinLevel();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            boxInside = true;
            stayTime = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            boxInside = false;
            stayTime = 0f;
        }
    }

    void WinLevel()
    {
        SceneManager.LoadSceneAsync("LoseUI"); // Load the win scene (make sure to set this up in your build settings)
        Time.timeScale = 0f; // pause game
    }
}