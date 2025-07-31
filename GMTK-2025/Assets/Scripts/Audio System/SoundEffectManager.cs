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
    [SerializeField] private Slider sfxSlider;

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


        float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = savedVolume;
        SetVolume(savedVolume);

        sfxSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }

    void Update()
    {

    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void OnSliderValueChanged()
    {
        SetVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
}
