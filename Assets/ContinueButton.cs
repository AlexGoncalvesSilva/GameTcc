using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private void Start()
    {
    
    }

    public void OnContinueButtonClicked()
    {
        // Verifica o progresso do jogador
        if (CountPistas.allCollectedCluesCenario1)
        {
            SceneManager.LoadScene("Cenario2"); // Carrega o cenário 2
        }
        else if (CountPistas.allCollectedCluesCenario2)
        {
            SceneManager.LoadScene("Cenario3"); // Carrega o cenário 3
        }
        else if (CountPistas.allCollectedCluesCenario3)
        {
            SceneManager.LoadScene("Cenario4"); // Carrega o cenário 4
        }
        else
        {
            SceneManager.LoadScene("Cenario1"); // Carrega o cenário 1
        }
    }
}
