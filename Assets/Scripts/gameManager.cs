using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerRb;
    
    public PLayerController playerController;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            playerRb.bodyType = RigidbodyType2D.Static;   //prevent user from moving once dead.
            gameObject.GetComponent<PLayerController>().enabled = false;

        }
    }
}
