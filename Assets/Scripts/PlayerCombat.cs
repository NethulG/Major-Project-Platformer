using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.Tilemaps;
using UnityEngine;


#pragma warning disable
public class PlayerCombat : MonoBehaviour
{
    private Animator animator;

    
    public Vector2 boxSize;
    public float castDist;
    public LayerMask groundLayer;

    private Transform attackTransform;
    [SerializeField] private float attackableRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    private RaycastHit2D[] hit;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded())
        {
            Attack();
        }
        
    }

    private bool isGrounded()
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

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            animator.SetTrigger(AnimationStrings.AttackTrigger);


        }
    }
    
    
    private void OnDrawGizmos() //allows for easier editing of ray/wire cast tools.
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }
}
