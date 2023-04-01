using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Obstacles/Enemies")]
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject[] spawnPoints;

    [Header("Settings")]
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;

    [Header("Keybinds")]
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Movement movement;

    private float speedMultiplier;
    private float distance;
    private bool isPaused = false;

    private void Update()
    {
        // distance text
        distanceText.text = "Distance: " + distance.ToString("N3");
        // distance calculation
        distance += Time.deltaTime * 3f;
        // speed multiplier for the obstacles to become faster overtime
        speedMultiplier += Time.deltaTime + 0.00005f;
        // timer for spawning obstacles
        timer += Time.deltaTime;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int _rng = Random.Range(0, 3);
            Instantiate(obstacle, spawnPoints[_rng].transform.position, Quaternion.identity);
        }

        HandleInputs();

        if (movement.pState == PlayerState.Dead)
        {
            RestartGame();
        }
    }

    /// <summary>
    /// Returns speed multiplier
    /// </summary>
    /// <returns>Speed Multiplier</returns>
    public float GetSpeedMultiplier()
    {
        return speedMultiplier;
    }

    /// <summary>
    /// Restart the game
    /// </summary>
    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Pause/Unpause the game depending if it's already paused or not
    /// </summary>
    public void PauseGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            isPaused = true;
        }
    }

    /// <summary>
    /// Handles player inputs
    /// </summary>
    private void HandleInputs()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
        }
    }
}
