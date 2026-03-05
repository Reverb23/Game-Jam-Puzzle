using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playercalc : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

        }
    }
}
