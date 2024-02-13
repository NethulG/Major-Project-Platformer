using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string SceneToLoad; 
    public GameObject player;
    public GameObject needKeys;
    public GameObject exitLevel;
    private bool withinCollider = false;
    
    public bool isDoor;
    
    private Animator animator;
    
    //check the number of keys
    public float numKey;
    private float keysCollected = 0f;

    private bool entryGranted;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (entryGranted && Input.GetKey(KeyCode.E))
        {
            finishLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDoor && collision.gameObject.CompareTag("Player"))
        {
            if (keysCollected == numKey)
            {
                animator.SetTrigger(AnimationStrings.Open);
                //activate the prompt to enter the next level ("e")
                //Debug.Log("You have all keys");
                entryGranted = true;
                
                
            }
            if (keysCollected != numKey) 
            { 
                //display you are missing keys 
            }
            
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        entryGranted = false;
        animator.SetTrigger(AnimationStrings.close);
    }

    private void finishLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void incrementKeysCollected()
    {
        keysCollected++;
    }
}
