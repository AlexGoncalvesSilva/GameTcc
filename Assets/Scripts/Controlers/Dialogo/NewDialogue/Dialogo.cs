using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;

    public UnityEvent IsTalking;
    public UnityEvent OnFinishTalking;

    public bool playerIntetact;

    public Transform PlayerCamera;
    public float MaxDistance = 5;

    public static Dialogo instance;

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
                if (hit.transform.tag == "NPC")
                {
                    playerIntetact= true;
                    playerDioalogo();
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
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                DialogoController.instance.ProximaFala(falas[0]);
                Analyze.instance.PistaDialogo();
            }
            else
            {
                DialogoController.instance.ProximaFala(falas[1]);
                CameraController.instance.CanMoveCamera();
            }

            dialogoConcluido = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            
           
        }
        
    }
}
