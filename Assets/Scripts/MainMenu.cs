using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadSceneAsync("ScarlettScene");
    }
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
