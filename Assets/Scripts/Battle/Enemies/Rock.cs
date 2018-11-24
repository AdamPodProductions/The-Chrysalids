using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(2);
        BattleManager.instance.PlayerTurn();
    }

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }
}
