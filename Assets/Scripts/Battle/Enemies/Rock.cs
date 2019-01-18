using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject rubble;
    public Transform player;

    private void SpawnRubble()
    {
        Instantiate(rubble, new Vector2(player.position.x + Random.Range(-1, 1), 1.15f), rubble.transform.rotation);
    }

    private IEnumerator RubbleAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.35f);
            SpawnRubble();
        }

        yield return new WaitForSeconds(2.5f);
        BattleManager.instance.PlayerTurn();
    }

    public void Attack()
    {
        StartCoroutine(RubbleAttack());
    }
}
