using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipSing  {
    AudioClip clip;
    public ClipSing(AudioClip audio)
    {
        clip = audio;
    }
    public void Play(AudioSource audioSource)
    {
        audioSource.clip=clip;
        audioSource.Play();
    }
}
