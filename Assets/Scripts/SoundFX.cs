using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    [SerializeField] float soundFXVolume = 0.8f;
    [SerializeField] AudioClip clickFX;
    AudioSource audioSource;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }


    public void OnSoundFXClick()
    {
        audioSource.PlayOneShot(clickFX, soundFXVolume);
    }
}
