using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    private LayerMask interactLayermask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    public GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    private RaycastHit hit;

    private bool isInteracting = false; // Variável para controlar se o personagem está interagindo

    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);

        // Verifica se o personagem está interagindo com algum objeto ou algum menu está aberto
        if (isInteracting)
        {
            pickUpUI.SetActive(false);
            return; // Sai do método para evitar a execução das próximas condições
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, interactLayermask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }
        else
        {
            pickUpUI.SetActive(false);
        }
    }

    // Método para definir se o personagem está interagindo ou não
    public void SetInteracting(bool interacting)
    {
        isInteracting = interacting;
    }
}
