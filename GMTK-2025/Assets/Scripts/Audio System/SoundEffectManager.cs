using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static AudioSource audioSource;
    private static SoundEffectLibrary soundEffectLibrary;

    private void Awake()
    {

    }

    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundEffectLibrary = GetComponent<SoundEffectLibrary>();


        float sfxSavedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        // sfxSlider.value = savedVolume;
        SetVolume(sfxSavedVolume);
    }

    void Update()
    {

    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
