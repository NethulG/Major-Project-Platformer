using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string SceneToLoad;



    public GameObject LevelTransition;
    
    private bool withinCollider = false;
    
    
    
    private Animator animator;
    private Animator levelAnimator;
    
    //check the number of keys
    public float numKey;
    private float keysCollected = 0f;

    private bool entryGranted;
    private float transitionTime = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        levelAnimator = LevelTransition.GetComponent<Animator>();
    }

    private void Update()
    {
        if (entryGranted && Input.GetKey(KeyCode.E))
        {
            loadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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

    private void loadNextLevel()
    {
        StartCoroutine(loadLevel());
    }

    public void incrementKeysCollected()
    {
        keysCollected++;
    }

   IEnumerator loadLevel()
    {
        levelAnimator.SetTrigger(AnimationStrings.nextScene);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneToLoad);
    }
}
