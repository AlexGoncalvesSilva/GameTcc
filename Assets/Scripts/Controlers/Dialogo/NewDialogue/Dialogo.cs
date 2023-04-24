using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;


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

            //Para de andar
    
            if (!dialogoConcluido)
            {
                Cursor.lockState = CursorLockMode.Confined;
                DialogoController.instance.ProximaFala(falas[0]);
                Analyze.instance.PistaDialogo();
            }
            else
            {
                DialogoController.instance.ProximaFala(falas[1]);
            }

            dialogoConcluido = true;
        }
        
    }
}
