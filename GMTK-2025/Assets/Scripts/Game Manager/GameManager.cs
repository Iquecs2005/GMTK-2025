using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject playerObject;
    private LixoController lixoControllerRef;

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
        return playerObject;
    }

    public LixoController GetLixoControllerRef()
    {
        if (lixoControllerRef != null) return lixoControllerRef;

        lixoControllerRef = GameObject.Find("LevelCompletedCanvas").GetComponent<LixoController>();
        return lixoControllerRef;
    }
}
