using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string SceneToLoad;



    public GameObject LevelTransition;
    
   
    
    
    
    private Animator animator;
    private Animator levelAnimator;
    
    //check the number of keys
    public int numKey;
    private int keysCollected = 0;

    private bool entryGranted;
    private float transitionTime = 0.5f;
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }
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
                audioManager.playSFX(audioManager.doorOpen);
                entryGranted = true;
                
                
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
