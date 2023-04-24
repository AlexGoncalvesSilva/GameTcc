using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    Resposta respostaData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProximaFala()
    {
        DialogoController.instance.ProximaFala(respostaData.proximaFala);
    }

    public void Setup(Resposta resposta) 
    {
        respostaData = resposta; 
    }

}
