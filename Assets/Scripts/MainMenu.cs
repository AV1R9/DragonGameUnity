using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string playGameLevel;

    public void PlayGame()
    {
       Application.LoadLevel(playGameLevel);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
