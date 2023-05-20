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

    private bool isInteracting = false; // Vari�vel para controlar se o personagem est� interagindo

    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);

        // Verifica se o personagem est� interagindo com algum objeto ou algum menu est� aberto
        if (isInteracting)
        {
            pickUpUI.SetActive(false);
            return; // Sai do m�todo para evitar a execu��o das pr�ximas condi��es
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

    // M�todo para definir se o personagem est� interagindo ou n�o
    public void SetInteracting(bool interacting)
    {
        isInteracting = interacting;
    }
}
