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
    public AudioClip healClip;

    private Animator animator;

    private void Start()
    {
        maxHealth = health;

        animator = GetComponent<Animator>();
    }

    private IEnumerator Shake()
    {
        transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(transform.position.x - 0.6f, transform.position.y);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(transform.position.x + 0.6f, transform.position.y);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(transform.position.x - 0.6f, transform.position.y);
        yield return new WaitForSeconds(0.1f);

        transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
        yield return new WaitForSeconds(0.1f);
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

        ui.UpdateUIDamage(damage);

        if (health <= 0)
        {
            BattleManager.instance.StopMusic();
            animator.SetBool("Alive", false);
        }
    }

    public void Heal(int healing)
    {
        SetHealth(health + healing);

        source.PlayOneShot(healClip);

        ui.UpdateUIHeal(healing);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("Level_004");
    }
}
