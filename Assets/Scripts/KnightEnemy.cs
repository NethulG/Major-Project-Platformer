using System.Collections;
using System.Collections.Generic;
using UnityEngine;
# pragma warning disable
public class KnightEnemy : MonoBehaviour
{
    public float walkSpeed;
    public enum WalkingDirection { Left, Right }; //readable understanding of what Left and right do.
    private WalkingDirection walkDirection;
    private Vector2 walkdirectionVector;
    Rigidbody2D knightRb;
    

    //checking for walls and edges
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    //check ground
    public Vector2 boxSize;
    public float castDist;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Awake()
    {
        knightRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (IsWalled())
        {
            //FlipDirection();
        }
        knightRb.velocity = new Vector2(walkSpeed * Vector2.right.x, knightRb.velocity.y);
    }

    private WalkingDirection WalkDirection
    {
        get {  return walkDirection; }
        set { 
            if (walkDirection != value)
            {
                //flip the direction
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkingDirection.Right)
                {
                    walkdirectionVector = Vector2.right;
                } else if (value == WalkingDirection.Left)
                {
                    walkdirectionVector = Vector2.left;
                }
            }
            
            
            walkDirection = value; 
        }
    }

    private bool IsWalled() //enables us to check if the enemy is touching a wall mid-air. Requires child GameO.
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private bool isGrounded() // checks whether player is on the ground.
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDist, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnDrawGizmos() //allows for easier editing of ray/wire cast tools.
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }
}
