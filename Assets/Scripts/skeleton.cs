using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody skeletonRB;
    // Start is called before the first frame update
    void Start()
    {
        skeletonRB = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        skeletonRB.velocity = new Vector2(walkSpeed * Vector2.right.x, skeletonRB.velocity.y);
    }
}
