using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextBox : MonoBehaviour
{
    public string[] textToSay;
    public float lettersPerSec;

    public GameObject textBox;
    public Text text;

    private void Start()
    {
        Say();
    }

    private IEnumerator SayCoroutine()
    {
        string currentString = textToSay[Random.Range(0, textToSay.Length)];

        for (int i = 0; i < currentString.Length; i++)
        {
            text.text += currentString[i];
            yield return new WaitForSeconds(1f / lettersPerSec);
        }

        yield return new WaitForSeconds(1);

        textBox.SetActive(false);
    }

    public void Say()
    {
        textBox.SetActive(true);
        StartCoroutine(SayCoroutine());
    }
}
