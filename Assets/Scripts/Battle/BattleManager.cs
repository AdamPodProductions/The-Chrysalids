using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public PlayerHealth playerHealth;
    public PlayerDamage playerDamage;
    public EnemyHealth enemyHealth;
    public EnemyTextBox enemyTextBox;

    public MonoBehaviour enemyBehaviour;

    public AttackBar attackBar;

    public GameObject battleObj;

    public GameObject battleOptions;
    public GameObject fightButton;
    public TextBox textBox;

    public GameObject fight;

    public GameObject playerMovement;
    public GameObject playerHealthUI;

    public AudioSource musicSource;

    private void OnEnable()
    {
        instance = this;

        playerHealth = FindObjectOfType<PlayerHealth>();
        playerDamage = FindObjectOfType<PlayerDamage>();
        enemyHealth = FindObjectOfType<EnemyHealth>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PlayerTurn();
    }

    private IEnumerator SelectFightButton()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(fightButton);
    }

    public void PlayerTurn()
    {
        TogglePlayerMovement(false);
        ToggleBattleOptions(true);
        playerHealthUI.SetActive(true);

        StartCoroutine(SelectFightButton());

        textBox.SayText("This is a test. Do not be alarmed. This is just a drill.", 15, () => Input.GetKeyDown(KeyCode.Space));
    }

    public void EnemyTurn()
    {
        if (enemyHealth.health > 0)
        {
            playerHealth.ToggleInvincibility(false);
            TogglePlayerMovement(true);
            ToggleBattleOptions(false);
            enemyBehaviour.SendMessage("Attack");
            enemyTextBox.SayRandomText();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ToggleBattleOptions(bool toggle)
    {
        battleOptions.SetActive(toggle);
    }

    public void ToggleFight(bool toggle)
    {
        textBox.HideTextBox();

        fight.SetActive(toggle);
        attackBar.ToggleMovement(toggle);

        if (!toggle)
        {
            attackBar.transform.localPosition = Vector2.left * 3.825f;
        }
    }

    public void TogglePlayerMovement(bool toggle)
    {
        playerMovement.SetActive(toggle);
        playerHealthUI.SetActive(toggle);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
