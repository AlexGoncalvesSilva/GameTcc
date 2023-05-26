using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OfficeFeedback : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textFinal;

    public int i = 0;

    public int t = 0;

    public Transform PlayerCamera;
    public bool playerInteractWithNotebook;
    public bool alredyInteract;
    public bool showText;
    public bool needHelp;
    public float MaxDistance = 5;
    public Collider colliderToDisable;


    public static OfficeFeedback instance;

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
        checkNotebook();
        textFeedback();
        textsTut();
    }

    void checkNotebook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.gameObject.layer == 10)
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
        if (i <= 5 && playerInteractWithNotebook == true)
        {
            PlayerMovement.instance.canMove = false;
        }
        else { PlayerMovement.instance.canMove = true; }

        if (Input.GetKeyDown(KeyCode.E) && playerInteractWithNotebook == true && alredyInteract == false)
        {
            StartCoroutine("rotinaText");
            if (showText == true)
            {
                i += 1;
                if (i == 1)
                {
                    text.text = "ENVIEI PARA O DEPARTAMENTO O QUE CONSEGUI NA JOALHERIA. AGORA TÁ NA HORA DE FOCAR NO OUTRO CASO";
                }
                else if (i == 2)
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

    IEnumerator rotinaText()
    {
        yield return new WaitForSeconds(1f);
        showText = true;
    }

    void textsTut()
    {
        if (t>= 1 && t <= 2)
        {
            PlayerMovement.instance.canMove = false;
        }
        else { PlayerMovement.instance.canMove = true; }

        if (needHelp == true && FirstTime.instance.alreadyRead== false)
        {
            if (t == 0)
            {
                text.text = "TENHO QUE ENVIAR OS MATERIAIS DESSE CASO PARA O DEPARTAMENTO.";
                t++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                t += 1;
                if (t == 1)
                {
                    text.text = "TENHO QUE ENVIAR OS MATERIAIS DESSE CASO PARA O DEPARTAMENTO.";
                }
                else if (t == 2)
                {
                    text.text = "TENHO QUE ACESSAR MEU NOTEBOOK";
                }
                else if( t == 3)
                {
                    text.text = "";
                    FirstTime.instance.alreadyRead = true;
                }

            }
        }

    }

    void DisableCollider()
    {
        colliderToDisable.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            needHelp = true;
            Debug.Log("Tut 1");
        }
    }

}
