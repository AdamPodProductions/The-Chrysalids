using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingTextBox : TextBox
{
    public string[] textToSay;

    public int currentIndex = 0;
    private bool loadLevel = false;
    private string levelToLoad = "";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Say();
        }
    }

    public void Say()
    {
        Action action = Say;
        action += PlayerMovement.instance.PlayerCanMove;
        string currentString = "";

        PlayerMovement.instance.canMove = false;

        if (currentIndex < textToSay.Length)
        {
            currentString = textToSay[currentIndex];
            currentIndex++;
        }
        else
        {
            currentIndex = 0;

            if (loadLevel)
            {
                loadLevel = false;
                SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
            }

            return;
        }

        SayText(currentString, 15, () => Input.GetKeyDown(KeyCode.Space), action);
    }

    public void Say(string levelToLoad)
    {
        Action action = Say;
        currentIndex++;
        action += PlayerMovement.instance.PlayerCanMove;

        this.levelToLoad = levelToLoad;
        loadLevel = true;

        SayText(textToSay[0], 15, () => Input.GetKeyDown(KeyCode.Space), action);
    }
}
