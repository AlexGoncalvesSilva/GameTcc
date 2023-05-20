using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMenu : MonoBehaviour
{
    public GameObject Panel;
    public Transform PlayerCamera;
    public Interactions interactionsScript; // Refer�ncia ao script "Interactions"
    [Header("MaxDistance")]
    public float MaxDistance = 5;
    public float CloseDistance = 10; // Dist�ncia para fechar o menu
    private bool openedPanel = false;

    // Start is called before the first frame update
    void Start()
    {
        // Obt�m a refer�ncia ao script "Interactions"
        interactionsScript = FindObjectOfType<Interactions>();
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

                        // Define que o personagem est� interagindo
                        interactionsScript.SetInteracting(true);
                    }
                    else
                    {
                        openedPanel = false;
                        Panel.SetActive(false);
                        Cursor.visible = false;

                        // Define que o personagem n�o est� mais interagindo
                        interactionsScript.SetInteracting(false);
                    }
                }
            }
            else
            {
                openedPanel = false;
                Panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                // Define que o personagem n�o est� mais interagindo
                interactionsScript.SetInteracting(false);
            }
        }

        // Verifica a dist�ncia entre o jogador e o carro para fechar o menu
        if (openedPanel && Vector3.Distance(transform.position, PlayerCamera.position) > CloseDistance)
        {
            openedPanel = false;
            Panel.SetActive(false);
            Cursor.visible = false;

            // Define que o personagem n�o est� mais interagindo
            interactionsScript.SetInteracting(false);
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
