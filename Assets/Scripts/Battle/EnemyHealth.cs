using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 200;
    public float maxHealth;

    public EnemyHealthUI ui;

    public AudioSource source;
    public AudioClip damageClip;

    private Animator animator;

    private void Start()
    {
        maxHealth = health;

        animator = GetComponent<Animator>();
    }

    private IEnumerator Shake()
    {
        transform.position = new Vector2(0.3f, 2);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(-0.3f, 2);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(0.3f, 2);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(-0.3f, 2);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(0, 2);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void Damage(int damage)
    {
        SetHealth(health - damage);

        source.PlayOneShot(damageClip);
        StartCoroutine(Shake());

        ui.UpdateUI(damage);

        if (health <= 0)
        {
            BattleManager.instance.StopMusic();
            animator.SetBool("Alive", false);
        }
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(0);
    }
}
