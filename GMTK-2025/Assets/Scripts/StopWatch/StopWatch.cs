using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float currentTime = 0;
    private bool running = true;
    
    private void FixedUpdate()
    {
        if (running) 
        {
            currentTime += Time.deltaTime;
            UpdateUI();
        }
    }

    public void SetTimer(bool value) 
    {
        running = value;
    }

    private void UpdateUI() 
    {
        int minutes = (int)currentTime / 60;
        int seconds = (int)currentTime % 60;

        //string displayText = string.Format("{0,02}:{1,02}", minutes, seconds);
        string displayText = $"{minutes:D02}:{seconds:D02}";

        timerText.text = displayText;
    }
}
