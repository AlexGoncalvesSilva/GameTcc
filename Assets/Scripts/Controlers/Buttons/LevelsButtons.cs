using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsButtons : MonoBehaviour
{

    private CountPistas countPistas;
    public Button levelUnlockedButton;
    
    private void Start()
    {
        countPistas = CountPistas.instance;
        levelUnlockedButton.interactable = CountPistas.allCollectedClues;
    }

    public void LevelButton(int i)
    {
        UiManager.instance.hidePanelLevels();
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.instance.CanMoveCamera();
        SceneManager.LoadScene(i);
    }
}
