using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable
public class keyCollection : MonoBehaviour
{
    public GameObject door;
    DoorController doorController;
    // Start is called before the first frame updateaudioManager audioManager;
    audioManager audioManager;

    

    void Awake()
    {
        doorController = door.GetComponent<DoorController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.playSFX(audioManager.pickKey);
            doorController.incrementKeysCollected();
            Destroy(gameObject);
        }
    }
}
