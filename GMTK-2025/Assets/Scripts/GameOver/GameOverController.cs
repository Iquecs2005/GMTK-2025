using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverHolder;

    private void Start()
    {
        GameManager.Instance.GetPlayerRef().GetComponent<PlayerController>().OnDeath.AddListener(ActivateGameOverScreen);
    }

    private void ActivateGameOverScreen() 
    {
        gameOverHolder.SetActive(true);
        SoundEffectManager.Play("GameOver");
    } 
}
