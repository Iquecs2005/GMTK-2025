using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // [SerializeField] GameObject continueBtn;

    // void Start()
    // {
    //     continueBtn = GetComponent
    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        Debug.Log(Time.timeScale);
    }

    public void Pause()
    {
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);

        if (pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
