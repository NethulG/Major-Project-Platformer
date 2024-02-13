using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string SceneToLoad; //identify the scene
    
    //identification of key or door
    public bool isDoor;
    public bool isKey;
    private Animator animator;
    
    //check the number of keys
    public float numKey;
    private float keysCollected = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDoor && collision.gameObject.CompareTag("Player"))
        {
            if (keysCollected == numKey)
            {
                //display the "press E to enter"
                // if the player presses E the next scene loads with a transition
                
            }
            if (keysCollected != numKey) 
            { 
                //display you are missing keys 
            }
            
        }

        if (isKey && collision.gameObject.CompareTag("Player"))
        {

        }
    }

    private void finishLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }


}
