using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnButtonClick() 
    {
        SoundEffectManager.Play("Click");
    }

    public void OnButtonHover()
    {
        SoundEffectManager.Play("MouseOver");
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
