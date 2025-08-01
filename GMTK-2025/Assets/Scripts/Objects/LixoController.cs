using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
            Time.timeScale = 0;
        }
    }

    private void UpdateLixoCounter() 
    {
        string displayText = $"{lixoCollected}/{lixoInScene}";
        lixoCounter.text = displayText;
    }
}
