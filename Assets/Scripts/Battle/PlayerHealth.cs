using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public Image healthImg;
    public Text healthAmount;

    public void SetHealth(int health)
    {
        this.health = health;

        healthImg.fillAmount = health / 20f;
        healthAmount.text = health + "/20";

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Damage(int damage)
    {
        SetHealth(health - damage);
    }
}
