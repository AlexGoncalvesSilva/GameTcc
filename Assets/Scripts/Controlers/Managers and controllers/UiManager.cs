using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject backImage;

    public GameObject panelLevels;

    public Text captionsText; //textos de legendas dos itens

    public Text levelCompleteText;

    public Image interactionImage;

    private void Awake()
    {
        instance = this;
    }

    public void showLevelCompleteText(string text)
    {
        levelCompleteText.text = text;
    }

    public void SetCaptions(string text)
    {
        captionsText.text = text;
    }

    public void showPanelLevels() 
    {
        panelLevels.SetActive(true);
    }

    public void hidePanelLevels()
    {
        panelLevels.SetActive(false);
    }

    public void SetBackImage(bool state)
    {
        backImage.SetActive(state);
        if (!state)
        {
            interactionImage.enabled = false;
        }
    }

    public void SetImage(Sprite sprite)
    {
        interactionImage.sprite = sprite;
        interactionImage.enabled = true;
    }
}
