using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header ("Health")]
    public int maxHealth = 3;
    public int currentHealth;
    public Slider healthBar;

    private bool firstBlockFell = false; // ignore the first box 

    [Header("Win Condition")]
    //public int boxesNeededToWin = 10;
    //private int boxesStacked = 0;
    public Collider2D winBarrier;
    private bool hasWon = false;

    [Header("UI Panels")]
    public GameObject startUI; 
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameStarted = false;
    private bool gameOver = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
    }

    // Called when player clicks start button 
    public void StartGame()
    {
        gameStarted = true;
        if (startUI != null) startUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Called when a block falls
    public void BlockFell()
    {
        if (!firstBlockFell)
        {
            firstBlockFell = true;
            return;
        }

        currentHealth--;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            LoseGame();
        }
    }

    public void BoxHitBarrier()
    {
        if (hasWon || !gameStarted) return;
        hasWon = true;

        WinGame();
    }


    // Called when a box is successfully stacked
    // Increments a counter, game won when meet target number
    //public void BoxPlaced()
    //{
    //    //if (!gameStarted) return;

    //    boxesStacked++;
    //    Debug.Log("Boxes stacked: " + boxesStacked);

    //    if (boxesStacked >= boxesNeededToWin)
    //    {
    //        Debug.Log("Win condition met");
    //        WinGame();
    //    }
    //}

    public void WinGame()
    {
        Debug.Log("WinGame triggered!");
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }


    private void LoseGame()
    {
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 0f;
        if (losePanel != null)
            losePanel.SetActive(true);
    }

    // UI Button - Restart current level
    public void RestartLevel()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // UI Button - Load next level (loops back to first if last)
    public void NextLevel()
    {
        Debug.Log("ajddjoawdaidi");
        Time.timeScale = 1f;
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene("MainMenu"); // optional, loop to main menu at last level
        else
            SceneManager.LoadScene(nextLevel);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // resume time
        SceneManager.LoadScene("MainMenu");
    }
}