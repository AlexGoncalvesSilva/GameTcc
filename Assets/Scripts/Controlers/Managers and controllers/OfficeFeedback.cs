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
                    text.text = "Enviei para o departamento o que consegui na joalheria. Agora é hora de focar no outro caso.";
                }
                else if (i == 2)
                {
                    text.text = "Vamos ver... É o caso de Daniel. Ele desapareceu há dois dias sem deixar nenhum rastro.";
                }
                else if (i == 3)
                {
                    text.text = "Bom, eu já organizei o caso no meu quadro.";
                }
                else if (i == 4)
                {
                    text.text = "Por onde devo começar exatamente? Bem, recebi uma cópia da chave da casa dele. Irei lá primeiro.";
                }
                else if (i == 5)
                {
                    text.text = "Depois irei na ONG onde ele trabalhava e lá conversarei com a Ana.";
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
                text.text = "Tenho que enviar os materiais desse caso para o departamento.";
                t++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                t += 1;
                if (t == 1)
                {
                    text.text = "Tenho que enviar os materiais desse caso para o departamento.";
                }
                else if (t == 2)
                {
                    text.text = "Tenho que acessar meu notebook.";
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
