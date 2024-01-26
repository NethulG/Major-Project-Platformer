using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable
public class PLayerController : MonoBehaviour
{
    //MADE BY NETHUL GOONAWARDENA
    // THIS SCRIPT CONTAINS:
        // Wallslide/Jump, Jump, Player Movement, Movement Animations
    //general
    private Rigidbody2D playerRb;
    private Animator animator;

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
    }

    

    
    void FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        bool shiftkey = Input.GetKey(KeyCode.LeftShift);
        MovePlayer(HorizontalInput, shiftkey);
        
        flipCharacter(HorizontalInput);

        

    }
    void Update()
    {
        Debug.Log(HorizontalInput);
        jump();
        wallSlide();
        updateAnimationState();
    }

    //-------------------------------subroutines-----------------------------------//
    private void updateAnimationState()
    {
        animator.SetBool("IsMoving", HorizontalInput != 0); //adjusts movement animations
        animator.SetBool("IsRunning", running); //adjusts running animations
    }

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

    private void flipCharacter(float horInput) //flips the character on movement
    {
        Vector3 characterScale = transform.localScale;
        if (horInput < 0)
        {
            characterScale.x = -1;
        }
        else if (horInput > 0) 
        { 
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
        //function must be adjusted for wall jumping and attacking

    }

    private void jump() //for jumping
    {
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false; //the player is not doublejumping
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded() || doubleJump)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, doubleJump ? doubleJumpForce : jumpForce); //allows for double jumping with the normal jump
                doubleJump = !doubleJump;
            }
            
        }
        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0f)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }

        //Debug.Log(doubleJump);
    }

    public bool isGrounded() // checks whether player is on the ground.
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

    private bool IsWalled() //enables us to check if the player is touching a wall mid-air. Requires child GameO.
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if (IsWalled() && !isGrounded() && HorizontalInput !=0f ) 
        { 
            isWallSliding = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, Mathf.Clamp(playerRb.velocity.y, - wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    
    private void OnDrawGizmos() //allows for easier editing of ray/wire cast tools.
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }

}
