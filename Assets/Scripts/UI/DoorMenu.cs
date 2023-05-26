using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMenu : MonoBehaviour
{
    public GameObject Panel;
    public Transform PlayerCamera;
    [Header("MaxDistance")]
    public float MaxDistance = 5;
    public float CloseDistance = 10; // Distância para fechar o menu
    private bool openedPanel = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "DoorMenu")
                {
                    if (!openedPanel)
                    {
                        openedPanel = true;
                        Panel.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                    }
                    else
                    {
                        openedPanel = false;
                        Panel.SetActive(false);
                        Cursor.visible = false;

                    }
                }
            }
            else
            {
                openedPanel = false;
                Panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // Verifica a distância entre o jogador e o objeto do menu para fechar o menu
        if (openedPanel && Vector3.Distance(transform.position, PlayerCamera.position) > CloseDistance)
        {
            openedPanel = false;
            Panel.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void LevelButton(int i)
    {
        SceneManager.LoadScene(i);
    }
}
