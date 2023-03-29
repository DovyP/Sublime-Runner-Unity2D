using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    // references
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>(); // temporary, not good to use Find
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the obstacle/enemy to the left
    /// </summary>
    private void Move()
    {
        rb.velocity = Vector2.left * (speed + gameManager.GetSpeedMultiplier());
    }
}
