using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberarNot : MonoBehaviour
{
    public GameObject PanelNotebook; 
    [Header("MaxDistance")]
    public float MaxDistance = 2;

    private bool openedPanel = false;

    public bool playerHasThePassword;

    public static LiberarNot instance;

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "HouseNotebook")
                {
                    if (!openedPanel)
                    {
                        openedPanel = true;
                        PanelNotebook.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.Confined;
                    }
                    else
                    {
                        openedPanel = false;
                        PanelNotebook.SetActive(false);
                        Cursor.visible = false;

                    }
                }
            }
            else
            {
                openedPanel = false;
                PanelNotebook.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        */

        CheckIfHavePassword();

    }

    void CheckIfHavePassword()
    {
        if(CheckPassword.instance.playerGetThePassword == true)
        {
            playerHasThePassword = true;
        }else if (CheckPassword.instance.playerGetThePassword == false)
        {
            playerHasThePassword = false;
        }
    }

    public void OpenPanel()
    {
        openedPanel = true;
        PanelNotebook.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void ClosePanel()
    {
        openedPanel = false;
        PanelNotebook.SetActive(false);
        ButtonNot.instance.blocoDeNotas.SetActive(false);
        Cursor.visible = false;
        PlayerInteraction.instance.notebook = false;
    }
}
