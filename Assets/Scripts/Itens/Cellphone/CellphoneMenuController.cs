using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneMenuController : MonoBehaviour
{
    private bool activatedCellphone = false;
    private bool menuOpened = false;
    public GameObject cellphoneObj;
    public GameObject menuCellphone;
    private CursorLockMode previousCursorLockMode;
    private bool previousCursorVisible;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (activatedCellphone)
            {
                // Se o celular estiver ativado e o menu estiver aberto, desativa o menu
                if (menuOpened && menuCellphone)
                {
                    menuCellphone.SetActive(false);
                    menuOpened = false;

                    // Restaura o estado anterior do mouse
                    Cursor.lockState = previousCursorLockMode;
                    Cursor.visible = previousCursorVisible;
                }

                // Desativa o celular
                if (cellphoneObj)
                {
                    cellphoneObj.SetActive(false);
                }

                activatedCellphone = false;
            }
            else
            {
                // Ativa o celular
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

                        // Restaura o estado anterior do mouse
                        Cursor.lockState = previousCursorLockMode;
                        Cursor.visible = previousCursorVisible;
                    }
                    else
                    {
                        menuCellphone.SetActive(true);
                        menuOpened = true;

                        // Salva o estado atual do mouse
                        previousCursorLockMode = Cursor.lockState;
                        previousCursorVisible = Cursor.visible;

                        // Libera o mouse e o torna visível
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
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
