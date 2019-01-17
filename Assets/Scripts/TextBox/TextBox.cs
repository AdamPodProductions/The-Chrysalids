using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public GameObject textBox;
    public Text text;

    public bool talking;

    public delegate void Action();

    private Coroutine lastCoroutine;

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";
        talking = true;

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeUntilBoxDisables);
        HideTextBox();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";
        talking = true;

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitUntil(conditionToDisableBox);
        HideTextBox();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, float timeUntilBoxDisables, Action action)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";
        talking = true;

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeUntilBoxDisables);
        HideTextBox();
        action();
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox, Action action)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";
        talking = true;

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitUntil(conditionToDisableBox);
        HideTextBox();
        action();
    }

    public void SayText(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, timeUntilBoxDisables));
    }

    public void SayText(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, conditionToDisableBox));
    }

    public void SayText(string text, float lettersPerSec, float timeUntilBoxDisables, Action action)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, timeUntilBoxDisables, action));
    }

    public void SayText(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox, Action action)
    {
        lastCoroutine = StartCoroutine(SayTextCoroutine(text, lettersPerSec, conditionToDisableBox, action));
    }

    public void HideTextBox()
    {
        if (lastCoroutine != null)
        {
            StopCoroutine(lastCoroutine);
        }

        talking = false;
        textBox.SetActive(false);
    }
}
