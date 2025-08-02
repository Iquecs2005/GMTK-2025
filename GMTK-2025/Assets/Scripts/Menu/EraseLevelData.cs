using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseLevelData : MonoBehaviour
{
    public void EraseData() 
    {
        PlayerPrefs.SetInt("ReachedIndex", 0);
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.Save();
    }
}
