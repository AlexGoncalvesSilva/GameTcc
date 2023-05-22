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

    public string cenaKey; // Chave única para cada cena
    public static bool allCollectedClues = false;

    public static CountPistas instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadPistas();
        UpdatePistaText();
        // UpdatePistaExtra();
        checkIfWin(); // Verifica se já coletou as pistas suficientes
    }

    public void AddPista()
    {
        if (countEvidenciasAnalisadas < MaxEvidenciasDaCena)
        {
            countEvidenciasAnalisadas++;
            UpdatePistaText();
            checkIfWin();
            SavePistas();
        }
    }


    void checkIfWin()
    {
        if (countEvidenciasAnalisadas >= MaxEvidenciasDaCena)
        {
            Debug.Log("Todas as pistas foram analisadas!");
            allCollectedClues = true;
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

    private void SavePistas()
    {
        PlayerPrefs.SetInt(cenaKey + "PistasColetadas", countEvidenciasAnalisadas);
        PlayerPrefs.Save();
    }

    private void LoadPistas()
    {
        if (PlayerPrefs.HasKey(cenaKey + "PistasColetadas"))
        {
            countEvidenciasAnalisadas = PlayerPrefs.GetInt(cenaKey + "PistasColetadas");
            UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
            checkIfWin(); // Verifica se já coletou as pistas suficientes
        }
    }

}