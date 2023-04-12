using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool canFinishLevel = false;

    public GameObject finishPanel;

    public UnityEvent finishLevel;
    public UnityEvent continueLevel;

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
        if (Input.GetKeyDown(KeyCode.F) && canFinishLevel)
        {
            finishPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            CameraController.instance.CantMoveCamera();
            finishLevel.Invoke();
        }
    }

    public void CancelFinish() 
    {
        CameraController.instance.CanMoveCamera();
        finishPanel.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        continueLevel.Invoke();
    }

}
