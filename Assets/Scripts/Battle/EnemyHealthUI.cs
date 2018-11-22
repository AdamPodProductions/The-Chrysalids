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
        healthImg.fillAmount = (GameManager.instance.enemyHealth.health / GameManager.instance.enemyHealth.maxHealth) * 1.0f;

        yield return new WaitForSeconds(1);

        ui.SetActive(false);
        GameManager.instance.ToggleFight(false);
    }

    public void UpdateUI(int damage)
    {
        StartCoroutine(UpdateUICoroutine(damage));
    }
}
