using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Obstacles/Enemies")]
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject[] spawnPoints;

    [Header("Settings")]
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float speedMultiplier;

    private void Update()
    {
        speedMultiplier += Time.deltaTime + 0.01f;

        timer += Time.deltaTime;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int _rng = Random.Range(0, 3);
            Instantiate(obstacle, spawnPoints[_rng].transform.position, Quaternion.identity);
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
}
