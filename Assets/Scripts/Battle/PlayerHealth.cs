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

    public AudioClip damageClip;

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

        yield return new WaitForSeconds(1.5f);

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Damage(int damage)
    {
        if (!invincible)
        {
            SetHealth(health - damage);
            audioSource.PlayOneShot(damageClip);
            StartCoroutine(Invincibility());
        }
    }
}
