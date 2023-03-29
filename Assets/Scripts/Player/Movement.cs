using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canRoll = true;

    [Header("Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxSlideTime;
    [SerializeField] private float slideTimer;

    [Header("Keybinds")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode rollKey = KeyCode.LeftControl;

    // booleans
    private bool isGrounded;
    private bool ShouldJump => Input.GetKey(jumpKey) && isGrounded;
    //private bool ShouldRoll => Input.GetKey(rollKey) && isGrounded;

    // references
    private Rigidbody2D rb;
    private Animator animator;

    // player state
    private PlayerState pState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        pState = PlayerState.Playing;
    }

    private void FixedUpdate()
    {
        if (canJump)
            HandleJump();

        if (canRoll)
            HandleRoll();
    }

    /// <summary>
    /// Handles jumping
    /// </summary>
    private void HandleJump()
    {
        if (ShouldJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            animator.SetBool("isRolling", false);
            animator.SetBool("isJumping", true);
        }
    }

    /// <summary>
    /// Handles rolling
    /// </summary>
    private void HandleRoll()
    {
        //if (!isGrounded)
            //return;

        if (Input.GetKeyDown(rollKey))
        {
            StartRoll();
        }

        if(Input.GetKeyUp(rollKey))
        {
            StopRoll();
        }
    }

    /// <summary>
    /// Adds force down to the player and starts the rolling animation
    /// </summary>
    private void StartRoll()
    {
        rb.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", true);
    }

    /// <summary>
    /// Stops rolling animation
    /// </summary>
    private void StopRoll()
    {
        animator.SetBool("isRolling", false);
    }

    /// <summary>
    /// Changes player state to dead and restarts the scene
    /// </summary>
    public void Die()
    {
        pState = PlayerState.Dead;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Checks if the collided game object is ground, if so, the player (bool isGrounded) is true. Ends jumping animation.
    /// </summary>
    /// <param name="collision">collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    /// <summary>
    /// Checks if the player exits the ground collision, if so, the player is no longer grounded.
    /// </summary>
    /// <param name="collision">collision</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// Checks if the player game object has collided with an obstacle, if so - calls Die(); function
    /// </summary>
    /// <param name="collision">collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
}
