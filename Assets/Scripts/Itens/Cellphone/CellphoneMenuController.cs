using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneMenuController : MonoBehaviour
{
    private bool activatedCellphone = false;
    private bool menuOpened = false;
    public GameObject cellphoneObj;
    public GameObject menuCellphone;
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (activatedCellphone)
            {
                if (menuOpened && menuCellphone)
                {
                    menuCellphone.SetActive(false);
                    menuOpened = false;

                    Cursor.lockState = previousCursorLockMode;
                    Cursor.visible = previousCursorVisible;

                    playerMovement.SetCanMove(true);
                    cameraController.CanMoveCamera();
                }

                if (cellphoneObj)
                {
                    cellphoneObj.SetActive(false);
                }

                activatedCellphone = false;
            }
            else
            {
                if (cellphoneObj)
                {
                    cellphoneObj.SetActive(true);
                }

                activatedCellphone = true;
            }
        }

        if (activatedCellphone && Input.GetKeyDown(KeyCode.M))
        {
            if (isCellphoneInHand())
            {
                if (menuCellphone)
                {
                    if (menuOpened)
                    {
                        menuCellphone.SetActive(false);
                        menuOpened = false;

                        Cursor.lockState = previousCursorLockMode;
                        Cursor.visible = previousCursorVisible;

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

    bool isCellphoneInHand()
    {
        // Adicione aqui a lógica para verificar se o celular está na mão do personagem
        return true;
    }
}
