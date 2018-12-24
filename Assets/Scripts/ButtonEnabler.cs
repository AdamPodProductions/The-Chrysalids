using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
    public void EnableButton()
    {
        GetComponent<Button>().enabled = true;

        if (name == "Play")
        {
            FindObjectOfType<Menu>().SelectPlayButton();
        }
    }
}
