using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotOffInteraction : MonoBehaviour
{

    public Collider colliderToDisable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disableCollider();
        activeCollider();
    }

    public void disableCollider()
    {
        if(OfficeFeedback.instance.playerInteractWithNotebook == true)
        {
            colliderToDisable.enabled = false;
            Debug.Log("Desativou");
        }
    }

    public void activeCollider()
    {
        if (OfficeFeedback.instance.alredyInteract == true)
        {
            colliderToDisable.enabled = true;
            Debug.Log("Ativou");
        }
    }
}
