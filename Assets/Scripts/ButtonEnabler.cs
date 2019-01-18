using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
    public bool startEnableButton;

    private void Start()
    {
        if (startEnableButton)
            EnableButton();
    }

    public void EnableButton()
    {
        GetComponent<Button>().enabled = true;

        if (name == "Play" || name == "Menu")
        {
            FindObjectOfType<Menu>().SelectPlayButton();
        }
    }
}
