using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class DialogueNPC : MonoBehaviour
{
    public string[] speechTxt;
    public string actorName;

    private DialogueControl dc;

    public bool playerClose;
    public bool isSpeaking;

    public static DialogueNPC instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerClose && !isSpeaking)
        {
            isSpeaking = true;
            dc.Speech(speechTxt, actorName);
        }
        if (isSpeaking == true)
        {
            DialogueControl.instance.NextSentence();
        }
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
            isSpeaking = false;
            DialogueControl.instance.exitArea();
        }
    }

}
