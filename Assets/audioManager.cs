using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField ] AudioSource musicSource;
    [SerializeField ] AudioSource sfxSource;

    public AudioClip boxBreak;
    public AudioClip dead;
    public AudioClip doorOpen;
    public AudioClip pickKey;
    public AudioClip swordHit;
    public AudioClip gameMusic;

    private void Start()
    {
        musicSource.clip = gameMusic;
        musicSource.Play();
    }
}
