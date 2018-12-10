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

    public void Say()
    {
        Action action;
        string currentString = "";

        if (currentIndex < textToSay.Length)
        {
            currentString = textToSay[currentIndex];
            currentIndex++;
            action = Say;
        }
        else
        {
            currentIndex = 0;
            action = Say;

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
        action = Say;

        this.levelToLoad = levelToLoad;
        loadLevel = true;

        SayText(textToSay[0], 15, () => Input.GetKeyDown(KeyCode.Space), action);
    }
}
