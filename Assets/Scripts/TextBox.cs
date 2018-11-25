using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public GameObject textBox;
    public Text text;

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitForSeconds(timeUntilBoxDisables);
        textBox.SetActive(false);
    }

    private IEnumerator SayTextCoroutine(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        float waitTime = 1f / lettersPerSec;

        textBox.SetActive(true);
        this.text.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(waitTime);
        }

        yield return new WaitUntil(conditionToDisableBox);
        textBox.SetActive(false);
    }

    public void SayText(string text, float lettersPerSec, float timeUntilBoxDisables)
    {
        StartCoroutine(SayTextCoroutine(text, lettersPerSec, timeUntilBoxDisables));
    }

    public void SayText(string text, float lettersPerSec, System.Func<bool> conditionToDisableBox)
    {
        StartCoroutine(SayTextCoroutine(text, lettersPerSec, conditionToDisableBox));
    }
}
