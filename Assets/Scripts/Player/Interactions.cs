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
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    private RaycastHit hit;

  

    private void Start()
    {
        
    }



    private void Update()
    {

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward *hitRange, Color.red);
        if(hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, interactLayermask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
            
            
        }
    }
}
