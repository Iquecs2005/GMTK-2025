using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LixoController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text lixoCounter;

    [Header("Events")]
    [SerializeField] private UnityEvent OnWin;

    private int lixoInScene = 0;
    private int lixoCollected = 0;
    private bool hasWon;

    public void AddLixoScene(int amount)
    {
        lixoInScene += amount;
        UpdateLixoCounter();
    }

    public void AddLixoCollected(int amount)
    {
        if (hasWon) return;

        lixoCollected += amount;
        UpdateLixoCounter();

        if (lixoCollected >= lixoInScene)
        {
            OnWin.Invoke();
            hasWon = true;
            UnlockNewLevel();
            Time.timeScale = 0;
        }
    }

    private void UpdateLixoCounter()
    {
        string displayText = $"{lixoCollected}/{lixoInScene}";
        lixoCounter.text = displayText;
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
