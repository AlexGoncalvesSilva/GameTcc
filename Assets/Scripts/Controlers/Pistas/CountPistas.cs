using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountPistas : MonoBehaviour
{
    public int countEvidenciasAnalisadasOng;
    public int countEvidenciasAnalisadasLaboratorio;
    public int countEvidenciasAnalisadasCenario2; // Nova variável
    public int maxEvidenciasOng;
    public int maxEvidenciasLaboratorio;
    public int maxEvidenciasCenario2; // Nova variável
    public int countEvidenciasUsadasOng;
    public int countEvidenciasUsadasLaboratorio;
    public int countEvidenciasUsadasCenario2; // Nova variável
    public TextMeshProUGUI pistaTextOng;
    public TextMeshProUGUI pistaTextLaboratorio;
    public TextMeshProUGUI pistaTextCenario2; // Nova variável
    public Button outroMenuButton;
    public Button outroMenuButtonCenario2; // Nova variável
    private Interactables interactables;

    public static bool allCollectedCluesOng = false;
    public static bool allCollectedCluesLaboratorio = false;
    public static bool allCollectedCluesCenario2 = false; // Nova variável

    public static CountPistas instance;

    public enum SceneType
    {
        Ong,
        Laboratorio,
        CenarioTutorial2 // Nova enumeração
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
        else if (sceneType == SceneType.CenarioTutorial2) // Nova condição
        {
            if (countEvidenciasAnalisadasCenario2 < maxEvidenciasCenario2)
            {
                countEvidenciasAnalisadasCenario2++;
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
            if (countEvidenciasAnalisadasOng >= maxEvidenciasOng && countEvidenciasUsadasOng >= maxEvidenciasOng)
            {
                Debug.Log("Todas as pistas da ONG foram analisadas e usadas!");
                allCollectedCluesOng = true;
                EnableOutroMenuButton();
            }
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            if (countEvidenciasAnalisadasLaboratorio >= maxEvidenciasLaboratorio && countEvidenciasUsadasLaboratorio >= maxEvidenciasLaboratorio)
            {
                Debug.Log("Todas as pistas do laboratório foram analisadas e usadas!");
                allCollectedCluesLaboratorio = true;
                EnableOutroMenuButton();
            }
        }
        else if (sceneType == SceneType.CenarioTutorial2) // Nova condição
        {
            if (countEvidenciasAnalisadasCenario2 >= maxEvidenciasCenario2 && countEvidenciasUsadasCenario2 >= maxEvidenciasCenario2)
            {
                Debug.Log("Todas as pistas do cenário 2 foram analisadas e usadas!");
                allCollectedCluesCenario2 = true;
                EnableOutroMenuButtonCenario2(); // Novo método
            }
        }
    }

    private void UpdatePistaText()
    {
        if (sceneType == SceneType.Ong)
        {
            pistaTextOng.text = string.Format("{0}/{1} Pistas Analisadas",
                countEvidenciasAnalisadasOng, maxEvidenciasOng,
                countEvidenciasUsadasOng, maxEvidenciasOng);
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            pistaTextLaboratorio.text = string.Format("{0}/{1} Pistas Analisadas",
                countEvidenciasAnalisadasLaboratorio, maxEvidenciasLaboratorio,
                countEvidenciasUsadasLaboratorio, maxEvidenciasLaboratorio);
        }
        else if (sceneType == SceneType.CenarioTutorial2) // Nova condição
        {
            pistaTextCenario2.text = string.Format("{0}/{1} Pistas Analisadas",
                countEvidenciasAnalisadasCenario2, maxEvidenciasCenario2,
                countEvidenciasUsadasCenario2, maxEvidenciasCenario2);
        }
    }

    private void EnableOutroMenuButton()
    {
        outroMenuButton.interactable = true;
    }

    private void EnableOutroMenuButtonCenario2() // Novo método
    {
        outroMenuButtonCenario2.interactable = true;
    }

    private void SavePistas()
    {
        if (sceneType == SceneType.Ong)
        {
            PlayerPrefs.SetInt("OngPistasColetadas", countEvidenciasAnalisadasOng);
            PlayerPrefs.SetInt("OngPistasUsadas", countEvidenciasUsadasOng);
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            PlayerPrefs.SetInt("LaboratorioPistasColetadas", countEvidenciasAnalisadasLaboratorio);
            PlayerPrefs.SetInt("LaboratorioPistasUsadas", countEvidenciasUsadasLaboratorio);
        }
        else if (sceneType == SceneType.CenarioTutorial2) // Nova condição
        {
            PlayerPrefs.SetInt("Cenario2PistasColetadas", countEvidenciasAnalisadasCenario2);
            PlayerPrefs.SetInt("Cenario2PistasUsadas", countEvidenciasUsadasCenario2);
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
                countEvidenciasUsadasOng = PlayerPrefs.GetInt("OngPistasUsadas");
                UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
                checkIfWin(); // Verifica se já coletou as pistas suficientes
            }
        }
        else if (sceneType == SceneType.Laboratorio)
        {
            if (PlayerPrefs.HasKey("LaboratorioPistasColetadas"))
            {
                countEvidenciasAnalisadasLaboratorio = PlayerPrefs.GetInt("LaboratorioPistasColetadas");
                countEvidenciasUsadasLaboratorio = PlayerPrefs.GetInt("LaboratorioPistasUsadas");
                UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
                checkIfWin(); // Verifica se já coletou as pistas suficientes
            }
        }
        else if (sceneType == SceneType.CenarioTutorial2) // Nova condição
        {
            if (PlayerPrefs.HasKey("Cenario2PistasColetadas"))
            {
                countEvidenciasAnalisadasCenario2 = PlayerPrefs.GetInt("Cenario2PistasColetadas");
                countEvidenciasUsadasCenario2 = PlayerPrefs.GetInt("Cenario2PistasUsadas");
                UpdatePistaText(); // Atualiza o texto da interface com o valor carregado
                checkIfWin(); // Verifica se já coletou as pistas suficientes
            }
        }
    }
}
