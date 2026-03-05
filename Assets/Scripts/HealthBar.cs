using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public GameObject snapEffect;
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("freese"); // jamie cant spell


        }
    }
}
