using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButtons : MonoBehaviour
{
    public void LevelButton(int i)
    {
        UiManager.instance.hidePanelLevels();
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.instance.CanMoveCamera();
        SceneManager.LoadScene(i);
    }
}
