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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FadeEdge"))
        {
            FindObjectOfType<PlayerMovement>().canMove = false;
            FindObjectOfType<Fade>().FadeOut();
        }
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
