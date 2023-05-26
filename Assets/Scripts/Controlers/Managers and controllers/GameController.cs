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

    public float timeToShowPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //AskToFinish();

        if (canFinishLevel && Input.GetKeyDown(KeyCode.F))
        {
            finishPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            CameraController.instance.CantMoveCamera();
            finishLevel.Invoke();
        }
    }

    public void AskToFinish()
    {
        if (canFinishLevel)
        {
            StartCoroutine(showFinishPanel());
        }
    }

    IEnumerator showFinishPanel()
    {
        yield return new WaitForSeconds(timeToShowPanel);
        finishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        CameraController.instance.CantMoveCamera();
        finishLevel.Invoke();
    }

    public void CancelFinish() 
    {
        CameraController.instance.CanMoveCamera();
        finishPanel.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        continueLevel.Invoke();
        UiManager.instance.showLevelCompleteText("Clique 'F' para retornar ao escritório");
        StartCoroutine(deleteText());
    }

    IEnumerator deleteText()
    {
        yield return new WaitForSeconds(2f);
        UiManager.instance.showLevelCompleteText("");
    }

}
