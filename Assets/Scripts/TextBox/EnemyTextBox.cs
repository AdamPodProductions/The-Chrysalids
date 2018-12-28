using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextBox : TextBox
{
    public string[] textToSay;

    private int currentIndex;
    private int previousIndex = -1;

    private void PickDifferentText()
    {
        currentIndex = Random.Range(0, textToSay.Length);

        if (currentIndex == previousIndex)
        {
            PickDifferentText();
        }

        SayText(textToSay[currentIndex], 15, 2);
    }

    public void SayRandomText()
    {
        currentIndex = Random.Range(0, textToSay.Length);

        if (textToSay.Length > 1)
        {
            if (currentIndex == previousIndex)
            {
                PickDifferentText();
            }
            else
            {
                SayText(textToSay[currentIndex], 15, 2);
                previousIndex = currentIndex;
            }
        }
    }
}
