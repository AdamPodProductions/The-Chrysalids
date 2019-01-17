using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkingTextBox : TextBox
{
    public string[] textToSay;
    public string levelToLoad = "";

    public int currentIndex = 0;
    private bool loadLevel = false;

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }

    public void Say()
    {
        Action action = Say;
        action += PlayerMovement.instance.PlayerCanMove;
        string currentString = "";

        if (levelToLoad != "")
            action += LoadLevel;

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
