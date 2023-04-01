using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// Exit and load main menu - linked to pause menu UI button
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
