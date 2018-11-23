using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnim : MonoBehaviour
{
    public void AttackEnemy()
    {
        BattleManager.instance.ToggleFight(false);
        BattleManager.instance.playerDamage.DamageEnemy();
    }
}
