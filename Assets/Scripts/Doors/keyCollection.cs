using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable
public class keyCollection : MonoBehaviour
{
    public GameObject door;
    DoorController doorController;
    // Start is called before the first frame update
    void Awake()
    {
        doorController = door.GetComponent<DoorController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorController.incrementKeysCollected();
            Destroy(gameObject);
        }
    }
}
