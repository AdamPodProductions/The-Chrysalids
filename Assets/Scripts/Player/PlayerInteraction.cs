using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.tag == "Interactable")
            {
                collision.GetComponent<Interactable>().Interact();
            }
        }
    }
}
