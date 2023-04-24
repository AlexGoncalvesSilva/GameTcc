using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyze : MonoBehaviour
{

    public bool playerClose;
    public bool thisEvidenceWasAnalyzed;

    public bool alredyTalk;

    public static Analyze instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        thisEvidenceWasAnalyzed = false;
    }

    private void Update()
    {
       // PistaDialogo();
    }

    public void PistaDialogo()
    {
        if (!alredyTalk)
        {
            CountPistas.instance.AddPista();
            Debug.Log("Funcionou a segunda parte");
            alredyTalk = true;
        }
        if (alredyTalk)
        {
            Debug.Log("Ja falou");
        }

        /*

        if (Input.GetKeyDown(KeyCode.X) && playerClose && !thisEvidenceWasAnalyzed)
        {
            thisEvidenceWasAnalyzed = true;
            if (thisEvidenceWasAnalyzed == true)
            {
                CountPistas.instance.AddPista();
                Debug.Log("Funcionou a segunda parte");
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && playerClose && thisEvidenceWasAnalyzed)
        {
            thisEvidenceWasAnalyzed = true;
        }
        */
    }

    public void PistaObjeto()
    {
        Debug.Log("Aq tá pegando via analyze");
        CountPistas.instance.AddPista(); 
        thisEvidenceWasAnalyzed = true;
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = false;
        }
    }
}
