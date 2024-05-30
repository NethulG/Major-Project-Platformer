using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableBox : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnSwordHit()
    {
        animator.SetTrigger("Hit");
        Destroy(gameObject, 1f);
    }
}
