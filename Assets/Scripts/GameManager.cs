using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject winUI;
    public GameObject loseUI;

    private bool gameStarted = false;

    void Start()
    {
        Time.timeScale = 0f; // pause game
        startUI.SetActive(true);
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        Time.timeScale = 1f;
        gameStarted = true;
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        loseUI.SetActive(true);
        SceneManager.LoadSceneAsync("loseUI");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}