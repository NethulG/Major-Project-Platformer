using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using UnityEditor;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

#pragma warning disable
public class PLayerController : MonoBehaviour
{
    
    private Rigidbody2D playerRb;
    private Animator animator;
    private bool shiftkey;
    private bool isFacingRight = true;

    //terrain movement
    public float walkSpeed;
    public float runSpeed;
    private float HorizontalInput;
    private bool running = false;

    //conditions
    private bool facingRight = true;

    //jump
    private bool doubleJump;
    public float jumpForce;
    public float doubleJumpForce;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //jumping raycast
    public Vector2 boxSize;
    public float castDist;
    public LayerMask groundLayer;

    //wall sliding and jumping
    private bool isWallSliding;
    private float wallSlideSpeed = 2f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }
    
    

    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        //wallSlide();
        if (canMove)
        {
            jump();
        }
        
        
        Flip();

        updateAnimationState();


    }

    void FixedUpdate()
    {
        
        
        shiftkey = Input.GetKey(KeyCode.LeftShift);
        
        
        if (canMove)
        {
            MovePlayer(HorizontalInput, shiftkey);
        }
        
        
        
        updateAnimationState();
    }

    //-------------------------------subroutines/methods-----------------------------------//


    public bool canMove { get {  return animator.GetBool(AnimationStrings.canMove); } } //get's the movement permission.
    private void MovePlayer(float horInput, bool sprint) // moves player horizontally, run/walk
    {
        if (sprint == true) //Enables horizontal movement, checking if sprint is on or off.
        {
            transform.Translate(Vector2.right * runSpeed * Time.deltaTime * horInput);
            running = true;
        }
        else
        {
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime * horInput);
            running = false;
        }
    }

    

    private void jump() //for jumping
    {
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime; //coyote time is setup to allow for player to jump 0.5s off the ground (forgiveness)
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false; //the player is not doublejumping
        }
        if (Input.GetButtonDown("Jump") && !isWallSliding)
        {

            if (coyoteTimeCounter > 0f || doubleJump)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, doubleJump ? doubleJumpForce : jumpForce); //allows for double jumping with the normal jump
                if (!doubleJump)
                {
                    animator.SetTrigger(AnimationStrings.jump);
                }
                doubleJump = !doubleJump;
                
            }
            
        }
        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        //Debug.Log(doubleJump);
    }

    private bool isGrounded() // checks whether player is on the ground.
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDist, groundLayer ))
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    //private bool IsWalled() //enables us to check if the player is touching a wall mid-air. Requires child GameO.
    //{
    //    return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    //}

    //private void wallSlide()
    //{
    //    if (IsWalled() && !isGrounded())  //only allows wallside if you are on a wall, not on the ground
    //    {
    //        isWallSliding = true;

    //        playerRb.velocity = new Vector2(playerRb.velocity.x, Mathf.Clamp(playerRb.velocity.y, -wallSlideSpeed, float.MaxValue));
    //    }
    //    else
    //    {
    //        isWallSliding = false;
    //    }

    //}




    private void updateAnimationState()
    {
        animator.SetBool(AnimationStrings.isMoving, HorizontalInput != 0); //adjusts movement animations
        animator.SetBool(AnimationStrings.isRunning, running);    //adjusts running animations
        animator.SetFloat(AnimationStrings.yVelocity, playerRb.velocity.y);
        animator.SetBool(AnimationStrings.isGrounded, isGrounded());
        animator.SetBool(AnimationStrings.sliding, isWallSliding);
    }

    public void Flip()
    {
        if (isFacingRight && HorizontalInput < 0f || !isFacingRight && HorizontalInput > 0f)  //checks player direction and if moveinput given
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnDrawGizmos() //allows for easier editing of ray/wire cast tools.
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }
}
