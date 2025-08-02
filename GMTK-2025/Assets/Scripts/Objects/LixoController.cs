using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LixoController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text currentTrashText;
    [SerializeField] private TMP_Text totalTrashText;
    [SerializeField] private TMP_Text winScreenTimerText;
    [SerializeField] private TMP_Text actualTimerText;
    [SerializeField] private AudioClip onWinMusic;

    [Header("Events")]
    [SerializeField] private UnityEvent OnWin;

    private int lixoInScene = 0;
    private int lixoCollected = 0;
    private bool hasWon;

    public void AddLixoScene(int amount)
    {
        lixoInScene += amount;
        UpdateUI();
    }

    public void AddLixoCollected(int amount)
    {
        if (hasWon) return;

        lixoCollected += amount;
        UpdateUI();

        if (lixoCollected >= lixoInScene && !GameManager.Instance.GetPlayerRef().GetComponent<PlayerController>().dead)
        {
            ActivateWin();
        }
    }

    private void ActivateWin() 
    {
        winScreenTimerText.text = "in " + actualTimerText.text;
        OnWin.Invoke();
        hasWon = true;
        AudioManager.musicInstance.PlayBackgroundMusic(false, onWinMusic);
        UnlockNewLevel();
        Time.timeScale = 0;
    }

    private void UpdateUI()
    {
        currentTrashText.text = lixoCollected.ToString();
        totalTrashText.text = lixoInScene.ToString();
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
