using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource _bgmAudioSource;
    private AudioSource _effectAudioSource;
    [SerializeField] private AudioClip[] audioClips; 


    protected override void Awake()
    {
        base.Awake();
                
        _bgmAudioSource = GetComponent<AudioSource>();
        _effectAudioSource = GetComponent<AudioSource>();
        
        _bgmAudioSource.playOnAwake = true;
        _bgmAudioSource.loop = true;
        
    }
    
    public void PlaySound(int soundIndex)
    {
        _effectAudioSource.PlayOneShot(audioClips[soundIndex]);
    }
}
