using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPistas : MonoBehaviour
{
    public int countEvidenciasAnalisadas;
    public int MaxEvidenciasDaCena;
    public Text pistaText;

    public static CountPistas instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdatePistaText();
    }

    public void AddPista()
    {
        countEvidenciasAnalisadas++;
        UpdatePistaText();
        checkIfWin();   
    }

    void checkIfWin()
    {
        if (countEvidenciasAnalisadas >= MaxEvidenciasDaCena)
        {
            UiManager.instance.showLevelCompleteText("Voc� encontrou todas as pistas da fase, clique 'F' para retornar");
            GameController.instance.canFinishLevel = true;
            GameController.instance.AskToFinish();
            Debug.Log("Todas as pistas foram analisadas!");

        }
    }

    private void UpdatePistaText()
    {
        pistaText.text = string.Format("{0}/{1} Pistas Analisadas", countEvidenciasAnalisadas, MaxEvidenciasDaCena);
    }

}