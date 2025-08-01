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

    public static void Play(string soundName)
    {
        float volume = 0;
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName, ref volume);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip, volume);
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

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
