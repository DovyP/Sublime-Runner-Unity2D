using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private float speedMultiplier;
    private float distance;
    private bool isPaused = false;

    private void Update()
    {
        distanceText.text = "Distance: " + distance.ToString();

        distance += Time.deltaTime * 3f;

        speedMultiplier += Time.deltaTime + 0.00005f;

        timer += Time.deltaTime;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int _rng = Random.Range(0, 3);
            Instantiate(obstacle, spawnPoints[_rng].transform.position, Quaternion.identity);
        }

        HandleInputs();
    }

    /// <summary>
    /// Returns speed multiplier
    /// </summary>
    /// <returns>Speed Multiplier</returns>
    public float GetSpeedMultiplier()
    {
        return speedMultiplier;
    }

    public void PauseGameMenu()
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

    private void HandleInputs()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGameMenu();
        }
    }
}
