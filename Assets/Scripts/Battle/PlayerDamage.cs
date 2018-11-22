using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 50;

    public void DamageEnemy()
    {
        GameManager.instance.enemyHealth.Damage(damage);
    }
}
