using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsNotLab : MonoBehaviour
{
    public Text text;

    public GameObject player;

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

    public void WrongButton()
    {
        text.text = "Aqui n�o tem nada de importante";
        StartCoroutine("RotinaTextNormal");
        Debug.Log("Clicou no bt");
    }

    public void CorrectButton()
    {
        text.text = "As grava��es das c�meras de seguran�a... Est� aberto em um dia espec�fico.";
        player.SetActive(true);
        StartCoroutine("RotinaTextNormal");
        Debug.Log("Clicou no da pista");
    }

    public void filesButton()
    {
        text.text = "Aqui tem muita coisa sobre esses rem�dios, o esquema com o prefeito e tem imagens e informa��es de um galp�o. Ser� que foi para l� que levaram Daniel?";
        StartCoroutine("RotinaNextText");
    }

    public void playerButton()
    {
        text.text = "As filmagens mostram Daniel, ele esteve realmente aqui, mas o seu padrasto chegou com mais uma pessoa, apagaram ele e o levaram";
        StartCoroutine("RotinaTextSecurity");
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
