using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerHealth playerHealth;
    public PlayerDamage playerDamage;
    public EnemyHealth enemyHealth;

    public GameObject battleObj;
    public GameObject gameOver;

    public GameObject fight;

    private void OnEnable()
    {
        instance = this;

        playerHealth = FindObjectOfType<PlayerHealth>();
        playerDamage = FindObjectOfType<PlayerDamage>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    private IEnumerator GameOverCoroutine()
    {
        gameOver.SetActive(true);
        battleObj.SetActive(false);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    public void ToggleFight(bool toggle)
    {
        fight.SetActive(toggle);
        FindObjectOfType<AttackBar>().ToggleMovement(toggle);
    }
}
