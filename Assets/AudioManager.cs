using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    [Header("----------- Audio Souce -----------")]
    [SerializeField] AudioSource musicSource;
     [Header("----------- Audio Souce -----------")]
    public AudioClip background;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
