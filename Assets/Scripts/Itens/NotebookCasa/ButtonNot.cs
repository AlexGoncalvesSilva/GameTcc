using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNot : MonoBehaviour
{
    public Text text;

    public GameObject blocoDeNotas;

    public static ButtonNot instance;

    private void Awake()
    {
        instance= this;
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
        text.text = "qui não tem nada de importante.";
        StartCoroutine("RotinaText");
        Debug.Log("Clicou no bt");
    }

    public void CorrectButton()
    {
        text.text = "Hmm, interessante...";
        blocoDeNotas.SetActive(true);
        StartCoroutine("RotinaText");
        Debug.Log("Clicou no da pista");
    }

    IEnumerator RotinaText()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }
}
