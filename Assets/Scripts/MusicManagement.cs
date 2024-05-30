using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagement : MonoBehaviour
{
    
    public static MusicManagement instance;

    
    public int[] musicScenesIndices = { 0, 1, 2 }; 

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        bool playMusic = false;
        foreach (int sceneIndex in musicScenesIndices)
        {
            if (scene.buildIndex == sceneIndex)
            {
                playMusic = true;
                break;
            }
        }

        
        if (playMusic)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}

