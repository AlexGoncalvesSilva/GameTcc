using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool canFinishLevel = false;

    public GameObject finishPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        AskToFinish();
    }

    public void AskToFinish()
    {
        CameraController.instance.CantMoveCamera();
        if (Input.GetKeyDown(KeyCode.F) && canFinishLevel)
        {
            finishPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CancelFinish() 
    {
        CameraController.instance.CanMoveCamera();
        finishPanel.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
    }

}
