using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool ShouldJump => Input.GetKey(jumpKey) && isGrounded;
    //private bool ShouldRoll => Input.GetKey(rollKey) && isGrounded;


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


    private bool isGrounded;

    // references
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canJump)
            HandleJump();

        if (canRoll)
            HandleRoll();
    }

    private void HandleJump()
    {
        if (ShouldJump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            animator.SetBool("isJumping", true);
        }
    }

    private void HandleRoll()
    {
        if (!isGrounded)
            return;

        if (Input.GetKeyDown(rollKey))
        {
            StartRoll();
        }

        if(Input.GetKeyUp(rollKey))
        {
            StopRoll();
        }
    }

    private void StartRoll()
    {
        rb.AddForce(Vector2.down * 5f, ForceMode2D.Impulse);
        animator.SetBool("isRolling", true);
    }

    private void StopRoll()
    {
        animator.SetBool("isRolling", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
