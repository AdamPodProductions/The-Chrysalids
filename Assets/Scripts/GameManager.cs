using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject battleObj;
    public GameObject gameOver;

    private void OnEnable()
    {
        instance = this;
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
}
