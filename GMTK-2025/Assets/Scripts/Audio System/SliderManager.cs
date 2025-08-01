using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] public Slider sfxSlider;
    [SerializeField] public Slider musicSlider;

    void Start()
    {
        float sfxSavedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = sfxSavedVolume;

        float MusicSavedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = MusicSavedVolume;
    }

    public void OnSfxSliderValueChanged()
    {
        SoundEffectManager.SetVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void OnMusicSliderValueChanged()
    {
        MusicManager.SetVolume(musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
