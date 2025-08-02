using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject gameOverHolder;

    [Header("Events")]
    [SerializeField] private UnityEvent OnGameOver;

    private void Start()
    {
        GameManager.Instance.GetPlayerRef().GetComponent<PlayerController>().OnDeath.AddListener(ActivateGameOverScreen);
    }

    private void ActivateGameOverScreen() 
    {
        gameOverHolder.SetActive(true);
        OnGameOver.Invoke();
        SoundEffectManager.Play("GameOver");
    } 
}
