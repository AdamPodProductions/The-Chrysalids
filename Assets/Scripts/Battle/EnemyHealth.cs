using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 200;
    public float maxHealth;

    public EnemyHealthUI ui;

    public AudioSource source;
    public AudioClip damageClip;

    private void Start()
    {
        maxHealth = health;
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
    }
}
