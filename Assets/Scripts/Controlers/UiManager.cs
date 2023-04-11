using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject panelLevels;

    public Text captionsText; //textos de legendas dos itens

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
