using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable
public class PLayerController : MonoBehaviour
{
    //DEBUG
    

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

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        jump();
    }

    
    void FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        bool shiftkey = Input.GetKey(KeyCode.LeftShift);
        MovePlayer(HorizontalInput, shiftkey);
        
        flipCharacter(HorizontalInput);

        updateAnimationState(); //update animations

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

        Debug.Log(doubleJump);
    }

    public bool isGrounded()
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

    private void OnDrawGizmos() //allows to edit the boxcast easily
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }

}
