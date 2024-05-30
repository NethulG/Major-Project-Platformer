using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableBox : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnSwordHit()
    {
        animator.SetTrigger(AnimationStrings.hit);
        Destroy(gameObject, 1f);
        audioManager.playSFX(audioManager.boxBreak);
    }
}
