using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneToLoad;
    public bool isEntrance;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isEntrance)
        {
            Debug.Log("Player has entered");
            animator.SetTrigger(AnimationStrings.PlayerEnter);
            
        }
    }



}
