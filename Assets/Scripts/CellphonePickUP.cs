using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphonePickUP : MonoBehaviour
{
    public GameObject heldObject; // Refer�ncia ao objeto do celular na m�o
    private bool isInteractable = false;

    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInteractable = false;
        }
    }

    private void PickUpObject()
    {
        heldObject.SetActive(true); // Ativa o objeto do celular na m�o
        heldObject.transform.position = transform.position; // Define a posi��o do objeto do celular na m�o
        heldObject.transform.rotation = transform.rotation; // Define a rota��o do objeto do celular na m�o
        gameObject.SetActive(false); // Desativa o objeto do celular na mesa
    }
}