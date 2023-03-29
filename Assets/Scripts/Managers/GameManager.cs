using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeBetweenSpawns)
        {
            timer = 0;
            int _rng = Random.Range(0, 3);
            Instantiate(obstacle, spawnPoints[_rng].transform.position, Quaternion.identity);
        }
    }

}
