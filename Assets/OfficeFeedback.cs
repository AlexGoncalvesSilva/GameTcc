using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class OfficeFeedback : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textFinal;

    public int i = 0;

    public Transform PlayerCamera;
    public bool playerInteractWithNotebook;
    public bool alredyInteract;
    public float MaxDistance = 5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkNotebook();
        textFeedback();
    }

    void checkNotebook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "OfficeNotebook")
                {
                    playerInteractWithNotebook = true;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }

    void textFeedback()
    {
        if (i <= 4 && playerInteractWithNotebook == true)
        {
            PlayerMovement.instance.canMove = false;
        }
        else { PlayerMovement.instance.canMove = true; }
        if (Input.GetKeyDown(KeyCode.E) && playerInteractWithNotebook == true && alredyInteract == false)
        {
            i += 1;
            if (i == 2)
            {
                text.text = "VAMOS VER... É O CASO DE DANIEL, ELE DESAPARECEU HÁ DOIS DIAS SEM DEIXAR NENHUM RASTRO";
            }
            else if (i == 3)
            {
                text.text = "BOM, EU JÁ ORGANIZEI O CASO NO MEU QUADRO";
            }
            else if (i == 4)
            {
                text.text = "POR ONDE DEVO COMEÇAR EXATAMENTE? BOM, RECEBI UMA CÓPIA DA CHAVE DA CASA DELE IREI LÁ PRIMEIRO";
            }
            else if (i == 5)
            {
                text.text = "DEPOIS IREI NA ONG ONDE ELE TRABALHAVA E LÁ CONVERSAREI COM A ANA.";
            }
            else if (i == 6)
            {
                text.text = "";
                playerInteractWithNotebook = false;
                alredyInteract = true;
            }
        }
    }

}