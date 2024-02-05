using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.Tilemaps;
using UnityEngine;


#pragma warning disable
public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    //Player PlayerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Flip() = Player.getc
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Fire");
            animator.SetTrigger(AnimationStrings.AttackTrigger);
        }
    }

    
}
