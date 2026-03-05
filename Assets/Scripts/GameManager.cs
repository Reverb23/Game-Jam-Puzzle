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
    public int boxesNeededToWin = 10;
    private int boxesStacked = 0;

    [Header("UI Panels")]
    public GameObject startUI; 
    public GameObject winPanel;
    public GameObject losePanel;

    private bool gameStarted = false;

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

        // Pause game at start unil StartGame()
        //Time.timeScale = 0f;

        // Show start UI, hide others 
        //if (startUI != null) startUI.SetActive(true);
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

    // Called when a box is successfully stacked
    // Increments a counter, game won when meet target number
    public void BoxPlaced()
    {
        if (!gameStarted) return;

        boxesStacked++;
        if (boxesStacked >= boxesNeededToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f;
        if (winPanel != null) winPanel.SetActive(true);
    }

    private void LoseGame()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
        if (losePanel != null) losePanel.SetActive(true);
    }

    // UI Button - Restart current level
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // UI Button - Load next level (loops back to first if last)
    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel >= SceneManager.sceneCountInBuildSettings)
            nextLevel = 0;
        SceneManager.LoadScene(nextLevel);
    }
}