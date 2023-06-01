using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountPistas : MonoBehaviour
{
    public int countEvidenciasAnalisadasCenario1;
    public int countEvidenciasAnalisadasCenario2;
    public int countEvidenciasAnalisadasCenario3;
    public int countEvidenciasAnalisadasCenario4;
    public int maxEvidenciasCenario1;
    public int maxEvidenciasCenario2;
    public int maxEvidenciasCenario3;
    public int maxEvidenciasCenario4;
    public TextMeshProUGUI pistaTextCenario1;
    public TextMeshProUGUI pistaTextCenario2;
    public TextMeshProUGUI pistaTextCenario3;
    public TextMeshProUGUI pistaTextCenario4;
    public Button botaoAvancoCenario1;
    public Button botaoAvancoCenario2;
    public Button botaoAvancoCenario3;
    public Button botaoAvancoCenario4;
    private Interactables interactables;

    public static bool allCollectedCluesCenario1 = false;
    public static bool allCollectedCluesCenario2 = false;
    public static bool allCollectedCluesCenario3 = false;
    public static bool allCollectedCluesCenario4 = false;

    public static CountPistas instance;

    public enum SceneType
    {
        Cenario1,
        Cenario2,
        Cenario3,
        Cenario4
    }

    public SceneType sceneType;

    public Animator uiAnimator; // Referência ao componente Animator da UI

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadPistas();
        UpdatePistaText();
        CheckIfWin();
    }

    public void AddPista()
    {
        switch (sceneType)
        {
            case SceneType.Cenario1:
                if (countEvidenciasAnalisadasCenario1 < maxEvidenciasCenario1)
                {
                    countEvidenciasAnalisadasCenario1++;
                    UpdatePistaText();
                    CheckIfWin();
                    SavePistas();
                }
                break;
            case SceneType.Cenario2:
                if (countEvidenciasAnalisadasCenario2 < maxEvidenciasCenario2)
                {
                    countEvidenciasAnalisadasCenario2++;
                    UpdatePistaText();
                    CheckIfWin();
                    SavePistas();
                }
                break;
            case SceneType.Cenario3:
                if (countEvidenciasAnalisadasCenario3 < maxEvidenciasCenario3)
                {
                    countEvidenciasAnalisadasCenario3++;
                    UpdatePistaText();
                    CheckIfWin();
                    SavePistas();
                }
                break;
            case SceneType.Cenario4:
                if (countEvidenciasAnalisadasCenario4 < maxEvidenciasCenario4)
                {
                    countEvidenciasAnalisadasCenario4++;
                    UpdatePistaText();
                    CheckIfWin();
                    SavePistas();
                }
                break;
        }

        // Ativa a animação da UI
        uiAnimator.SetTrigger("InOutUI");

        // Chamada para iniciar a rotina quando você coletar as pistas
        StartCoroutine(HideUIAfterSeconds(5.0f)); // Altere o valor '2.0f' para o número de segundos que você deseja esperar antes de esconder a UI
    }

    void CheckIfWin()
    {
        switch (sceneType)
        {
            case SceneType.Cenario1:
                if (countEvidenciasAnalisadasCenario1 == maxEvidenciasCenario1)
                {
                    allCollectedCluesCenario1 = true;
                    EnableBotaoAvancoCenario1();
                }
                break;
            case SceneType.Cenario2:
                if (countEvidenciasAnalisadasCenario2 == maxEvidenciasCenario2)
                {
                    allCollectedCluesCenario2 = true;
                    EnableBotaoAvancoCenario2();
                }
                break;
            case SceneType.Cenario3:
                if (countEvidenciasAnalisadasCenario3 == maxEvidenciasCenario3)
                {
                    allCollectedCluesCenario3 = true;
                    EnableBotaoAvancoCenario3();
                }
                break;
            case SceneType.Cenario4:
                if (countEvidenciasAnalisadasCenario4 == maxEvidenciasCenario4)
                {
                    allCollectedCluesCenario4 = true;
                    EnableBotaoAvancoCenario4();
                }
                break;
        }
    }

    void EnableBotaoAvancoCenario1()
    {
        botaoAvancoCenario1.interactable = true;
    }

    void EnableBotaoAvancoCenario2()
    {
        botaoAvancoCenario2.interactable = true;
    }

    void EnableBotaoAvancoCenario3()
    {
        botaoAvancoCenario3.interactable = true;
    }

    void EnableBotaoAvancoCenario4()
    {
        botaoAvancoCenario4.interactable = true;
    }

    void UpdatePistaText()
    {
        switch (sceneType)
        {
            case SceneType.Cenario1:
                pistaTextCenario1.text = countEvidenciasAnalisadasCenario1 + "/" + maxEvidenciasCenario1;
                break;
            case SceneType.Cenario2:
                pistaTextCenario2.text = countEvidenciasAnalisadasCenario2 + "/" + maxEvidenciasCenario2;
                break;
            case SceneType.Cenario3:
                pistaTextCenario3.text = countEvidenciasAnalisadasCenario3 + "/" + maxEvidenciasCenario3;
                break;
            case SceneType.Cenario4:
                pistaTextCenario4.text = countEvidenciasAnalisadasCenario4 + "/" + maxEvidenciasCenario4;
                break;
        }
    }

    void SavePistas()
    {
        PlayerPrefs.SetInt("CountEvidenciasAnalisadasCenario1", countEvidenciasAnalisadasCenario1);
        PlayerPrefs.SetInt("CountEvidenciasAnalisadasCenario2", countEvidenciasAnalisadasCenario2);
        PlayerPrefs.SetInt("CountEvidenciasAnalisadasCenario3", countEvidenciasAnalisadasCenario3);
        PlayerPrefs.SetInt("CountEvidenciasAnalisadasCenario4", countEvidenciasAnalisadasCenario4);
    }

    void LoadPistas()
    {
        countEvidenciasAnalisadasCenario1 = PlayerPrefs.GetInt("CountEvidenciasAnalisadasCenario1", 0);
        countEvidenciasAnalisadasCenario2 = PlayerPrefs.GetInt("CountEvidenciasAnalisadasCenario2", 0);
        countEvidenciasAnalisadasCenario3 = PlayerPrefs.GetInt("CountEvidenciasAnalisadasCenario3", 0);
        countEvidenciasAnalisadasCenario4 = PlayerPrefs.GetInt("CountEvidenciasAnalisadasCenario4", 0);
    }

    IEnumerator HideUIAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Toca a animação para esconder a UI
        uiAnimator.SetTrigger("InOutUI");
    }
}