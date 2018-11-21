using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 20;

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void Damage(int damage)
    {
        SetHealth(health - damage);
    }
}
