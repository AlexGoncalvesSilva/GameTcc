using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsNotLab : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject player;

    public GameObject panelPuzzleCam;

    public GameObject panelPuzzleFiles;

    public GameObject panelCamSec;

    public GameObject panelFileSec;

    public bool camSec;

    public bool fileSec;

    public static ButtonsNotLab instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonCripto() 
    {
        if (camSec)
        {                
            panelPuzzleCam.SetActive(true);
            camSec = false;

        }
        if (fileSec)
        {
            panelPuzzleFiles.SetActive(true);
            fileSec = false;
        }
    }

    public void WrongButton()
    {
        text.text = "Aqui n�o tem nada de importante.";
        StartCoroutine("RotinaTextNormal");
        Debug.Log("Clicou no bt");
    }

    public void filesCorrectButton()
    {
        text.text = "Esses arquivos est�o protegidos por outra senha e est�o criptografados.";
        panelFileSec.SetActive(true);
        fileSec = true;
        StartCoroutine("RotinaTextNormal");
    }

    public void camCorrectButton()
    {
        Debug.Log("clicou");
        text.text = "Esse programa est� protegido por outra senha e est� criptografado.";
        panelCamSec.SetActive(true);
        camSec = true;
        StartCoroutine("RotinaTextNormal");
    }

    public void CamButton()
    {
        text.text = "As grava��es das c�meras de seguran�a est�o abertas em um dia espec�fico.";
        player.SetActive(true);
        StartCoroutine("RotinaTextNormal");
        panelPuzzleCam.SetActive(false);
        panelCamSec.SetActive(false);
    }

    public void filesButton()
    {
        text.text = "Aqui h� muitas informa��es sobre esses rem�dios e o esquema com o prefeito, incluindo imagens e informa��es de um galp�o. Ser� que foi para l� que levaram Daniel?";
        panelFileSec.SetActive(false);
        panelPuzzleFiles.SetActive(false);
        StartCoroutine("RotinaNextText");
    }

    public void playerButton()
    {
        text.text = "As filmagens mostram que Daniel esteve realmente aqui, mas seu padrasto chegou com mais uma pessoa, apagaram-no e o levaram.";
        StartCoroutine("RotinaTextSecurity");
    }

    public void closePlayer()
    {
        player.SetActive(false );
    }

    IEnumerator RotinaTextNormal()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

    IEnumerator RotinaTextSecurity()
    {
        yield return new WaitForSeconds(5f);
        text.text = "Para onde ser� que levaram ele?";
        StartCoroutine("RotinaTextNormal");
    }
    IEnumerator RotinaNextText()
    {
        yield return new WaitForSeconds(4f);
        text.text = "";
    }

}
