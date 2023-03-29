using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool ShouldJump => Input.GetKey(jumpKey) && isGrounded;


    [Header("Abilities")]
    [SerializeField] private bool canJump = true;

    [Header("Settings")]
    [SerializeField] private float jumpForce;

    [Header("Keybinds")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;


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
        {
            HandleJump();
        }
    }

    private void HandleJump()
    {
        if (ShouldJump)
        rb.AddForce(Vector2.up * jumpForce);
        // play animation [add later]
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
