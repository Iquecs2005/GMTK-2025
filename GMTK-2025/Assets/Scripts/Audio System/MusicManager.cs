using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(false, backgroundMusic);
        }

        float MusicSavedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        SetVolume(MusicSavedVolume);
    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        audioSource.UnPause();

        if (audioClip == audioSource.clip) return;

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        if (audioSource != null)
        {
            if (resetSong)
            {
                audioSource.Stop();
            }
            audioSource.Play();
        }
    }

    static public void PauseBackgroundMusic()
    {
        audioSource.Pause();
    }
}
