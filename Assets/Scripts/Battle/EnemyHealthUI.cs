using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public GameObject ui;

    public Text damageText;
    public Image healthImg;

    private IEnumerator UpdateUIDamageCoroutine(int damage)
    {
        ui.SetActive(true);
        damageText.color = Color.red;
        damageText.text = damage.ToString();
        healthImg.fillAmount = (BattleManager.instance.enemyHealth.health / BattleManager.instance.enemyHealth.maxHealth) * 1.0f;

        yield return new WaitForSeconds(1);

        ui.SetActive(false);
        BattleManager.instance.EnemyTurn();
    }

    private IEnumerator UpdateUIHealCoroutine(int healing)
    {
        ui.SetActive(true);
        damageText.color = Color.green;
        damageText.text = healing.ToString();
        healthImg.fillAmount = (BattleManager.instance.enemyHealth.health / BattleManager.instance.enemyHealth.maxHealth) * 1.0f;

        yield return new WaitForSeconds(1);

        ui.SetActive(false);
        BattleManager.instance.PlayerTurn();
    }

    public void UpdateUIDamage(int damage)
    {
        StartCoroutine(UpdateUIDamageCoroutine(damage));
    }

    public void UpdateUIHeal(int damage)
    {
        StartCoroutine(UpdateUIHealCoroutine(damage));
    }
}
