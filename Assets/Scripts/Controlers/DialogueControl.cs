using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Text speechText;
    public Text actorNameText;


    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public static DialogueControl instance;

    private void Awake()
    {
        instance = this;
    }

    public void Speech(string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        DialogueNPC.instance.isSpeaking = true;
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (speechText.text == sentences[index])
            {
                //ainda tem falas
                if (index < sentences.Length - 1)
                {
                    index++;
                    speechText.text = "";
                    StartCoroutine(TypeSentence());
                }
                else //nao tem mais fala
                {
                    speechText.text = "";
                    index = 0;
                    StartCoroutine(isNotSpeaking());
                    dialogueObj.SetActive(false);
                }
            }
        }
    }

    public void exitArea()
    {
        speechText.text = "";
        index = 0;
        StartCoroutine(isNotSpeaking());
        dialogueObj.SetActive(false);
    }

    IEnumerator isNotSpeaking()
    {
        yield return new WaitForSeconds(1f);
        DialogueNPC.instance.isSpeaking = false;
    }
}