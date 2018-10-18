using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(string _level)
    {
        LoadManager.LoadScene(_level);

        return;
    }

    public void QuitGame()
    {
        Application.Quit();

        return;
    }
}
