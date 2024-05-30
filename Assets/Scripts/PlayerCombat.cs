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
    [SerializeField] private float attackableRange = 2f;
    [SerializeField] private LayerMask boxLayer;
    private RaycastHit2D[] hit;

    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }
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
            swingSword();
            audioManager.playSFX(audioManager.swordHit);
            animator.SetTrigger(AnimationStrings.AttackTrigger);


        }
    }
    private void swingSword()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, attackableRange, Vector2.right, 0f, boxLayer);
        if (hit.collider != null)
        {
            hit.collider.SendMessage("OnSwordHit");
        }
    }
    
    private void OnDrawGizmos() //allows for easier editing of ray/wire cast tools.
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, boxSize);
    }
}
