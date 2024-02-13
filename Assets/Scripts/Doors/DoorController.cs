using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
   
    public string SceneToLoad; //identify the scene
    public GameObject player;
    //identification of key or door
    public bool isDoor;
    
    private Animator animator;
    
    //check the number of keys
    public float numKey;
    private float keysCollected = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log(keysCollected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDoor && collision.gameObject.CompareTag("Player"))
        {
            if (keysCollected == numKey)
            {
                animator.SetTrigger(AnimationStrings.Open);
                
                Debug.Log("You have all keys");
                
            }
            if (keysCollected != numKey) 
            { 
                //display you are missing keys 
            }
            
        }

        
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
