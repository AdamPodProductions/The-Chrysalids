using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private TalkingTextBox talkingTextBox;

    private void Start()
    {
        talkingTextBox = FindObjectOfType<TalkingTextBox>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.tag == "Interactable" && !talkingTextBox.talking)
            {
                collision.GetComponent<Interactable>().Interact();
            }
        }
    }
}
