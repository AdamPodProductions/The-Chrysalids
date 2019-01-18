using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string levelToLoad;

    public void FadeOut()
    {
        GetComponent<Animator>().Play("FadeOut");
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
