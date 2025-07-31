using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpManager : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            menuButtons.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
            menuButtons.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundEffectManager.Play("UIHover");
    }

    public void OnSelect(BaseEventData eventData)
    {
        SoundEffectManager.Play("UIHover");
    }
}
