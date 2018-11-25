using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nikita : MonoBehaviour
{
    public GameObject dipshit;
    public GameObject juice;

    public Transform player;

    private void SpawnBullet()
    {
        Instantiate(dipshit, new Vector2(player.position.x + Random.Range(-1, 1), 1.15f), dipshit.transform.rotation);
    }

    private IEnumerator DipshitAttack()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.35f);
            SpawnBullet();
        }

        yield return new WaitForSeconds(4f);
        BattleManager.instance.PlayerTurn();
    }

    private IEnumerator Juice()
    {
        GameObject juiceGlass = Instantiate(juice, new Vector2(player.position.x, 1), juice.transform.rotation);
        if (juiceGlass.transform.position.x > 0.3f)
        {
            juiceGlass.transform.position = new Vector2(0.3f, 1);
        }
        else if (juiceGlass.transform.position.x < -0.3f)
        {
            juiceGlass.transform.position = new Vector2(-0.3f, 1);
        }

        yield return new WaitForSeconds(5);

        Destroy(juiceGlass);
        BattleManager.instance.PlayerTurn();
    }

    public void Attack()
    {
        int attackIndex = Random.Range(0, 2);

        if (attackIndex == 0)
        {
            StartCoroutine(DipshitAttack());
        }
        else
        {
            StartCoroutine(Juice());
        }
    }
}
