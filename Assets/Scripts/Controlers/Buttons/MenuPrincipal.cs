using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public GameObject panelInstructions;
    public GameObject panelCredits;

    public void PlayButton(int i)
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(i);
    }

    public void ActiveInstructions()
    {
        panelInstructions.SetActive(true);
    }

    public void ExitInstructions()
    {
        panelInstructions.SetActive(false);
    }

    public void ActiveCredits()
    {
        panelCredits.SetActive(true);
    }

    public void ExitCredits()
    {
        panelCredits.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
