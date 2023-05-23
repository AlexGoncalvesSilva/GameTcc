using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountPistas : MonoBehaviour
{
    public int countEvidenciasAnalisadasOng;
    public int countEvidenciasAnalisadasLaboratorio;
    public int maxEvidenciasOng;
    public int maxEvidenciasLaboratorio;
    public TextMeshProUGUI pistaTextOng;
    public TextMeshProUGUI pistaTextLaboratorio;
    public Button outroMenuButton;
    private Interactables interactables;

    public static bool allCollectedCluesOng = false;
    public static bool allCollectedCluesLaboratorio = false;

    public static CountPistas instance;

    public enum SceneType
    {
        Ong,
        Laboratorio
    }

    public SceneType sceneType;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadPistas();
        UpdatePistaText();
        checkIfWin(); // Verifica se já coletou as pistas suficientes
    }

    public void AddPista()
    {
        if (sceneType == SceneType.Ong)
        {
            if (countEvidenciasAnalisadasOng < maxEvidenciasOng)
            {
                countEvidenciasAnalisadasOng++;
                UpdatePistaText();
                checkIfWin();
                SavePistas();
            }
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            if (countEvidenciasAnalisadasLaboratorio < maxEvidenciasLaboratorio)
            {
                countEvidenciasAnalisadasLaboratorio++;
                UpdatePistaText();
                checkIfWin();
                SavePistas();
            }
        }
    }


    void checkIfWin()
    {
        if (sceneType == SceneType.Ong)
        {
            if (countEvidenciasAnalisadasOng >= maxEvidenciasOng)
            {
                Debug.Log("Todas as pistas da ONG foram analisadas!");
                allCollectedCluesOng = true;
                EnableOutroMenuButton();
            }
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            if (countEvidenciasAnalisadasLaboratorio >= maxEvidenciasLaboratorio)
            {
                Debug.Log("Todas as pistas do laboratório foram analisadas!");
                allCollectedCluesLaboratorio = true;
                EnableOutroMenuButton();
            }
        }
    }

    private void UpdatePistaText()
    {
        if (sceneType == SceneType.Ong)
        {
            pistaTextOng.text = string.Format("{0}/{1} Pistas Analisadas", countEvidenciasAnalisadasOng, maxEvidenciasOng);
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            pistaTextLaboratorio.text = string.Format("{0}/{1} Pistas Analisadas", countEvidenciasAnalisadasLaboratorio, maxEvidenciasLaboratorio);
        }
    }

    private void EnableOutroMenuButton()
    {
        outroMenuButton.interactable = true;
    }

    private void SavePistas()
    {
        if (sceneType == SceneType.Ong)
        {
            PlayerPrefs.SetInt("OngPistasColetadas", countEvidenciasAnalisadasOng);
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            PlayerPrefs.SetInt("LaboratorioPistasColetadas", countEvidenciasAnalisadasLaboratorio);
        }

        PlayerPrefs.Save();
    }

    private void LoadPistas()
    {
        if (sceneType == SceneType.Ong)
        {
            if (PlayerPrefs.HasKey("OngPistasColetadas"))
            {
                countEvidenciasAnalisadasOng = PlayerPrefs.GetInt("OngPistasColetadas");
                UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
                checkIfWin(); // Verifica se já coletou as pistas suficientes
            }
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            if (PlayerPrefs.HasKey("LaboratorioPistasColetadas"))
            {
                countEvidenciasAnalisadasLaboratorio = PlayerPrefs.GetInt("LaboratorioPistasColetadas");
                UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
                checkIfWin(); // Verifica se já coletou as pistas suficientes
            }
        }
    }
}
