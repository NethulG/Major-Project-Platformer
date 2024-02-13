using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneToLoad;
    public bool isDoor;
    public bool isKey;
    private Animator animator;
    
    public float numKey;
    private float keysCollected = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDoor)
        {

        }

        if (isKey)
        {

        }
    }




}
