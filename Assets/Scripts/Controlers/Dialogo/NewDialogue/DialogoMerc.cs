using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogoMerc : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    public TextMeshProUGUI NameNPC;

    private bool dialogoConcluido = false;

    public UnityEvent IsTalking;
    public UnityEvent OnFinishTalking;

    public bool playerIntetact;

    public Transform PlayerCamera;
    public float MaxDistance = 5;

    public static DialogoMerc instance;

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
        playerInteraction();
    }

    void playerInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIntetact == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "NPCMerc")
                {
                    playerIntetact = true;
                    playerDioalogo();
                    RotateNpx.instance.Interact();
                }
            }
            else
            {
                playerIntetact = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void playerDioalogo()
    {
        if (playerIntetact)
        {
            IsTalking.Invoke();
            CameraController.instance.CantMoveCamera();

            if (!dialogoConcluido)
            {
                Debug.Log("Dialogando agoraaa");
                NameNPC.text = "Atendente";
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                DialogoController.instance.ProximaFala(falas[0]);
                CountPistas.instance.AddPista();
                //Analyze.instance.PistaDialogo();
            }
            else
            {
                Debug.Log("Dialogou ja sdasas");
                NameNPC.text = "Atendente";
                DialogoController.instance.ProximaFala(falas[1]);
                CameraController.instance.CanMoveCamera();
            }

            dialogoConcluido = true;
        }
    }

    public void finished()
    {
        StartCoroutine("RotinaInteract");
    }

    IEnumerator RotinaInteract()
    {
        yield return new WaitForSeconds(3f);
        playerIntetact = false;
    }
}
