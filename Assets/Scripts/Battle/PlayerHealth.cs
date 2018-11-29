using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public Image healthImg;
    public Text healthAmount;
    public Button test;

    public AudioClip damageClip;
    public AudioClip healClip;

    public float invincibilityTime = 1.5f;

    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    public bool invincible;

    private IEnumerator Invincibility()
    {
        ToggleInvincibility(true);
        yield return new WaitForSeconds(invincibilityTime);
        ToggleInvincibility(false);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;

        if (health > 20)
        {
            health = 20;
        }
        if (health < 0)
        {
            health = 0;
            BattleManager.instance.GameOver();
        }

        healthImg.fillAmount = health / 20f;
        healthAmount.text = health + "/20";
    }

    public void Damage(int damage)
    {
        if (!invincible)
        {
            SetHealth(health - damage);

            if (health > 0)
            {
                audioSource.PlayOneShot(damageClip);
                StartCoroutine(Invincibility());
            }
        }
    }

    public void Heal(int healing)
    {
        SetHealth(health + healing);

        audioSource.PlayOneShot(healClip);
    }

    public void ToggleInvincibility(bool toggle)
    {
        invincible = toggle;
        spriteRenderer.color = toggle ? Color.gray : Color.white;
    }
}
