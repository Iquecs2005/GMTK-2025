using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip musicClip; 
    
    void Start()
    {
        AudioManager.musicInstance.PlayBackgroundMusic(false, musicClip);
    }
}
