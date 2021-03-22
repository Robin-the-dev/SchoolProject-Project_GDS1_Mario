/*
 * Player(Mario) must have components of
 * Rigidbody 2D, -> Mass: 1, Linear Drag: 0, Gravity Scale: 8, Freeze Rotation Z in Constraints must be ticked, Collision Detection: Continuous
 * Capsule Collider 2D(in stand position),
 * Box Collider 2D(in crouch position), -> must be ticked off and resize collider to crouch position of Player(Mario)
 * PlayerMovement Script.
 *
 * right and left arrow to move
 * left shift to sprint
 * space to jump
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    CapsuleCollider2D capsuleCollider2D;
    BoxCollider2D boxCollider2D;

    public float playerSpeed = 5f;
    public float horizontalMove;
    private float sprintMultiplier = 1.0f;
    [Range(0.1f, 0.9f)] public float acceleration = 0.7f;
    private float minSprint = 1.0f;
    private float maxSprint = 2.0f;

    public float jumpForce = 10f;
    private bool onGround = true;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private float groundCheckRadius = 0.1f;
    private bool stoppedJumping = true;
    [Range(0.1f, 0.5f)] public float jumpTime = 0.25f;
    private float jumpTimeCounter;

    private bool isFacingRight = true;

    private bool isCrouched = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // I think these methods in Update method will be equivalent method in CharacterController class
    void Update()
    {
        // All methods MUST BE in Update method, not FixedUpdate!!!
        Movement();
        Jump();
        Crouch();
        FlipPlayer();
    }

    void Movement() {
        // Player Movement (walk and sprint)
        horizontalMove = Input.GetAxis("Horizontal") * playerSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && sprintMultiplier <= maxSprint && !isCrouched) {
            sprintMultiplier = Mathf.Clamp(sprintMultiplier + acceleration * Time.deltaTime, minSprint, maxSprint);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || horizontalMove == 0.0f)
            sprintMultiplier = minSprint;

        horizontalMove = Input.GetKey(KeyCode.LeftShift) ? horizontalMove * sprintMultiplier : horizontalMove;

        if(!isCrouched) {
            rb2d.velocity = new Vector2(horizontalMove, rb2d.velocity.y);
        }
    }

    void Jump() {
        // Player Jump - press longer to jump higher

        // This is onGround check code
        // There should be empty game object in Player's feet as a child to check that Player is on the ground
        // And Ground should be layered like 'Ground' and be assigned
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (onGround) {
            jumpTimeCounter = jumpTime;
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && onGround) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            stoppedJumping = false;
        }

        if((Input.GetKey(KeyCode.Space)) && !stoppedJumping) {
            if(jumpTimeCounter > 0) {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) && !stoppedJumping) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

    void FlipPlayer() {
        // Flip Player where player is facing
        if(horizontalMove > 0.0f && isFacingRight == false) {
            isFacingRight = !isFacingRight;

            Vector2 localScale = transform.localScale;

            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else if(horizontalMove < 0.0f && isFacingRight == true) {
            isFacingRight = !isFacingRight;

            Vector2 localScale = transform.localScale;

            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    void Crouch() {
        if(Input.GetKey(KeyCode.DownArrow)) {
            boxCollider2D.enabled = true;
            capsuleCollider2D.enabled = false;
            isCrouched = true;
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            boxCollider2D.enabled = false;
            capsuleCollider2D.enabled = true;
            isCrouched = false;
        }
    }
}
