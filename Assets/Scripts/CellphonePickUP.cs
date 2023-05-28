using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphonePickUP : MonoBehaviour
{
    public GameObject heldObject; // Referência ao objeto do celular na mão
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
        heldObject.SetActive(true); // Ativa o objeto do celular na mão
        heldObject.transform.position = transform.position; // Define a posição do objeto do celular na mão
        heldObject.transform.rotation = transform.rotation; // Define a rotação do objeto do celular na mão
        gameObject.SetActive(false); // Desativa o objeto do celular na mesa
    }
}