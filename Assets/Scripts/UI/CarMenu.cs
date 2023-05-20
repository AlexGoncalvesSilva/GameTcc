using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMenu : MonoBehaviour
{
    public GameObject Panel;
    public Transform PlayerCamera;
    [Header("MaxDistance")]
    public float MaxDistance = 5;
    public float CloseDistance = 10; // Distância para fechar o menu
    private bool openedPanel = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "Car")
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

        // Verifica a distância entre o jogador e o carro para fechar o menu
        if (openedPanel && Vector3.Distance(transform.position, PlayerCamera.position) > CloseDistance)
        {
            openedPanel = false;
            Panel.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void LoadOfficeScene()
    {
        SceneManager.LoadScene("OfficeScene");
    }

    public void LoadOngScene()
    {
        SceneManager.LoadScene("ONGScene");
    }
}
