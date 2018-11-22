using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public Image healthImg;
    public Text healthAmount;

    public AudioClip damageClip;

    public float invincibilityTime = 1.5f;

    private bool invincible;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator Invincibility()
    {
        invincible = true;
        spriteRenderer.color = Color.gray;

        yield return new WaitForSeconds(invincibilityTime);

        invincible = false;
        spriteRenderer.color = Color.white;
    }

    public void SetHealth(int health)
    {
        this.health = health;

        healthImg.fillAmount = health / 20f;
        healthAmount.text = health + "/20";

        if (health <= 0)
        {
            BattleManager.instance.GameOver();
        }
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
}
