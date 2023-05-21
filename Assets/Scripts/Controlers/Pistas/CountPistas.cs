using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountPistas : MonoBehaviour
{
    public int countEvidenciasAnalisadas;
    public int MaxEvidenciasDaCena;
    public TextMeshProUGUI pistaText;
    public TextMeshProUGUI pistaExtra;
    public Button outroMenuButton;
    private Interactables interactables;

    public static CountPistas instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdatePistaText();
        UpdatePistaExtra();
    }
    public void AddPista()
    {
        countEvidenciasAnalisadas++;
        UpdatePistaText();
        checkIfWin();
        //UpdatePistaExtra();
        
    }


    void checkIfWin()
    {
        if (countEvidenciasAnalisadas >= MaxEvidenciasDaCena)
        {
            Debug.Log("Todas as pistas foram analisadas!");
            EnableOutroMenuButton();
        }
    }

    private void UpdatePistaText()
    {
        pistaText.text = string.Format("{0}/{1} Pistas Analisadas", countEvidenciasAnalisadas, MaxEvidenciasDaCena);
    }

    private void UpdatePistaExtra()
    {
        pistaExtra.text = string.Format("{0} Pistas Extras", countEvidenciasAnalisadas);
    }

    private void EnableOutroMenuButton()
    {
        outroMenuButton.interactable = true;
    }
}
