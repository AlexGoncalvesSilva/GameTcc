using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    public TextMeshProUGUI text;

    public static PuzzleController instance;

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

    public void conseguiu()
    {
        text.text = "Consegui!!";
        CountPistas.instance.AddPista();
        StartCoroutine("RotinaText");
    }

    public void NConseguiu()
    {
        text.text = "Droga, não consegui. Vou tentar de novo.";
        StartCoroutine("RotinaText");
    }

    IEnumerator RotinaText()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

}
