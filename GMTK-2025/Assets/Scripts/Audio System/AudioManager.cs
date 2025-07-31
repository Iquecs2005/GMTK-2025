using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static MusicManager musicInstance;
    public static SoundEffectManager sfxInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            musicInstance = GetComponentInChildren<MusicManager>();
            sfxInstance = GetComponentInChildren<SoundEffectManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
