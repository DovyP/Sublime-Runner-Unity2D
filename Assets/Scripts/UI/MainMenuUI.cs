using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {
        // play main menu music
    }

    /// <summary>
    /// Called from the Start button
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Exit the application
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
