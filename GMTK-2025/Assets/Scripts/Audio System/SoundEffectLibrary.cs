using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    //string == sound name
    private Dictionary<string, List<AudioInformation>> soundDictionary;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioInformation>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name, ref float volume)
    {
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioInformation> audioClips = soundDictionary[name];
            if (audioClips.Count > 0)
            {
                int randomClipIndex = UnityEngine.Random.Range(0, audioClips.Count);

                volume = audioClips[randomClipIndex].volume;
                return audioClips[randomClipIndex].audioClip;
            }
        }
        return null;
    }
}

[System.Serializable]
public class SoundEffectGroup
{
    public string name;
    public List<AudioInformation> audioClips;
}

[System.Serializable]
public class AudioInformation
{
    [Range(0, 1)]
    public float volume = 1;
    public AudioClip audioClip;
}