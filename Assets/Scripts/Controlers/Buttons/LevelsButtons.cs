using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsButtons : MonoBehaviour
{
    private CountPistas countPistas;
    public Button ongLevelButton;
    public Button laboratorioLevelButton;

    private bool ongUnlocked;
    private bool laboratorioUnlocked;

    private void Start()
    {
        countPistas = CountPistas.instance;
        ongUnlocked = CountPistas.allCollectedCluesOng;
        laboratorioUnlocked = CountPistas.allCollectedCluesLaboratorio;

        ongLevelButton.interactable = ongUnlocked;
        laboratorioLevelButton.interactable = laboratorioUnlocked;
    }

    public void LevelButton(int i)
    {
        UiManager.instance.hidePanelLevels();
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.instance.CanMoveCamera();
        SceneManager.LoadScene(i);
    }
}
