using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneMenuController : MonoBehaviour
{
    private bool activatedCellphone = false;
    private bool menuOpened = false;
    public GameObject cellphoneObj;
    public GameObject menuCellphone;
    public GameObject cellphoneLightObject; // Referência para o objeto da luz do celular
    private PlayerMovement playerMovement;
    private CameraController cameraController;
    private CursorLockMode previousCursorLockMode;
    private bool previousCursorVisible;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!activatedCellphone)
            {
                if (cellphoneObj)
                {
                    cellphoneObj.SetActive(true);
                    activatedCellphone = true;
                }
                if (cellphoneLightObject)
                {
                    cellphoneLightObject.SetActive(true); // Ativa o objeto da luz do celular
                }
            }
            else
            {
                if (menuOpened && menuCellphone)
                {
                    menuCellphone.SetActive(false);
                    menuOpened = false;

                    Cursor.lockState = previousCursorLockMode;
                    Cursor.visible = previousCursorVisible;
                    previousCursorVisible = true; // Garante que o cursor fique visível ao fechar o canvas

                    playerMovement.SetCanMove(true);
                    cameraController.CanMoveCamera();
                }

                if (cellphoneObj)
                {
                    cellphoneObj.SetActive(false);
                    activatedCellphone = false;
                }
                if (cellphoneLightObject)
                {
                    cellphoneLightObject.SetActive(false); // Desativa o objeto da luz do celular
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuCellphone)
            {
                if (menuOpened)
                {
                    menuCellphone.SetActive(false);
                    menuOpened = false;

                    Cursor.lockState = previousCursorLockMode;
                    Cursor.visible = previousCursorVisible;
                    previousCursorVisible = true; // Garante que o cursor fique visível ao fechar o canvas

                    playerMovement.SetCanMove(true);
                    cameraController.CanMoveCamera();
                }
                else
                {
                    menuCellphone.SetActive(true);
                    menuOpened = true;

                    previousCursorLockMode = Cursor.lockState;
                    previousCursorVisible = Cursor.visible;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    playerMovement.SetCanMove(false);
                    cameraController.CantMoveCamera();
                }
            }
        }
    }
}
