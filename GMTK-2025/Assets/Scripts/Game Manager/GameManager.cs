using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject playerObject;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    public GameObject GetPlayerRef() 
    {
        if (playerObject != null) return playerObject;

        playerObject = GameObject.Find("Player");
        print(playerObject);
        return playerObject;
    }
}
