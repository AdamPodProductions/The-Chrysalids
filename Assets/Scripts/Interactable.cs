using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string[] textToSay;

    private TalkingTextBox talkingTextBox;

    private void Start()
    {
        talkingTextBox = FindObjectOfType<TalkingTextBox>();
    }

    public void Interact()
    {
        talkingTextBox.textToSay = textToSay;
        talkingTextBox.Say();
    }
}
