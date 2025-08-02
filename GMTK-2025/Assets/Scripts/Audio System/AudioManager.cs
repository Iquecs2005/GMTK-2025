using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static MusicManager musicInstance;
    public static SoundEffectManager sfxInstance;

    [SerializeField] private GameObject musicManagerObject; 
    [SerializeField] private GameObject sfxManagerObject; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            musicInstance = musicManagerObject.GetComponent<MusicManager>();
            MusicManager.audioSource = musicManagerObject.GetComponent<AudioSource>();
            sfxInstance = sfxManagerObject.GetComponent<SoundEffectManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
