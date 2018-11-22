using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnim : MonoBehaviour
{
    public void AttackEnemy()
    {
        GameManager.instance.playerDamage.DamageEnemy();
    }
}
