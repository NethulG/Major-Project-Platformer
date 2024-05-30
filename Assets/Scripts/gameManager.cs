using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D playerRb;
    [SerializeField] GameObject gameOver;
    public PLayerController playerController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezePositionX;//prevent user from moving once dead.
            gameObject.GetComponent<PLayerController>().enabled = false;
            animator.SetBool("isDead", true);
        }
        
        
    }
    
    private void setScreen()
    {
        gameOver.SetActive(true);
        Cursor.visible = true;
    }
}
