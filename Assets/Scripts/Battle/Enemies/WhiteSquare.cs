using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSquare : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;

    private void SpawnBullet()
    {
        Instantiate(bullet, new Vector2(player.position.x + Random.Range(-1, 1), 1.15f), Quaternion.identity);
    }

    private void SpawnDirectionalBullet()
    {
        Transform spawnedBullet = Instantiate(bullet, new Vector2(player.position.x + Random.Range(-1, 1), 1.15f), Quaternion.identity).transform;

        Vector3 diff = spawnedBullet.position - player.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        spawnedBullet.eulerAngles = new Vector3(0f, 0f, rotZ - 90);
    }

    private IEnumerator BulletAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.35f);
            SpawnBullet();
        }

        yield return new WaitForSeconds(2.5f);
        BattleManager.instance.PlayerTurn();
    }

    private IEnumerator DirectionalBulletAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.45f);
            SpawnDirectionalBullet();
        }

        yield return new WaitForSeconds(2.5f);
        BattleManager.instance.PlayerTurn();
    }

    private void Heal()
    {
        int healing = Random.Range(20, 40);
        BattleManager.instance.enemyHealth.Heal(healing);
    }

    public void Attack()
    {
        int attackIndex = Random.Range(0, 3);

        if (attackIndex == 0)
        {
            StartCoroutine(BulletAttack());
        }
        else if (attackIndex == 1)
        {
            StartCoroutine(DirectionalBulletAttack());
        }
        else if (attackIndex == 2)
        {
            Heal();
        }
    }
}
