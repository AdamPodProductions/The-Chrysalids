using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public GameObject ui;

    public Text damageText;
    public Image healthImg;

    private IEnumerator UpdateUICoroutine(int damage)
    {
        ui.SetActive(true);
        damageText.text = damage.ToString();
        healthImg.fillAmount = (BattleManager.instance.enemyHealth.health / BattleManager.instance.enemyHealth.maxHealth) * 1.0f;

        yield return new WaitForSeconds(1);

        ui.SetActive(false);
        BattleManager.instance.EnemyTurn();
    }

    public void UpdateUI(int damage)
    {
        StartCoroutine(UpdateUICoroutine(damage));
    }
}
