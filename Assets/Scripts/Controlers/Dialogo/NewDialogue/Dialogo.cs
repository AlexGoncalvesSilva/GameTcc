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



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            IsTalking.Invoke();
            CameraController.instance.CantMoveCamera();

            if (!dialogoConcluido)
            {
                Cursor.lockState = CursorLockMode.Confined;
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
}
