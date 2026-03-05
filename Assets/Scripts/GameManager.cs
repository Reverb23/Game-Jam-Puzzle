using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxHealth = 3;
    public int currentHealth;

    public Slider healthBar;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void BlockFell()
    {
        currentHealth--;

        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }


}















//    public GameObject startUI;
//    public GameObject winUI;
//    public GameObject loseUI;

//    private bool gameStarted = false;

//    void Start()
//    {
//        Time.timeScale = 0f; // pause game
//        startUI.SetActive(true);
//        winUI.SetActive(false);
//        loseUI.SetActive(false);
//    }

//    // Detecting block fell function 
//    public void BlockFell()
//    {
//        if (currentState != GameState.Playing) return;

//        currentHealth--;

//        healthBar.value = currentHealth;

//        if (currentHealth <= 0)
//        {
//            LoseGame();
//        }

//    }



//    public void StartGame()
//    {
//        startUI.SetActive(false);
//        Time.timeScale = 1f;
//        gameStarted = true;
//        SceneManager.LoadSceneAsync("ScarlettScene");
//    }

//    public void WinGame()
//    {
//        Time.timeScale = 0f;
//        winUI.SetActive(true);
//    }

//    public void LoseGame()
//    {
//        Time.timeScale = 0f;
//        loseUI.SetActive(true);
//        SceneManager.LoadSceneAsync("loseUI");
//    }

//    public void RestartLevel()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    public void NextLevel()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//    }
//}