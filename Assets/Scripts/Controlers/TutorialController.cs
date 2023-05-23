using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Text text;
    public GameObject textFinal;

    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textTutorial();
        finishedTutorial();
    }

    void textTutorial()
    {
        if (i <= 4)
        {
            PlayerMovement.instance.canMove = false;
        }
        else { PlayerMovement.instance.canMove = true; }
        if (Input.GetKeyDown(KeyCode.E))
        {
            i += 1;
            if (i == 1)
            {
                text.text = "PARA INTERAGIR COM OBJETOS E NPCs UTILIZE O 'E'";
            }
            else if (i == 2)
            {
                text.text = "AO FALAR COM OS NPCs UTILIZE O MOUSE PARA SELECIONAR A OPÇÃO DE RESPOSTA QUE VOCÊ DESEJA";
            }
            else if (i == 3)
            {
                text.text = "PARA ANDAR UTILIZE AS TECLAS 'W, A, S, D'";
            }
            else if (i == 4)
            {
                text.text = "UTILIZE 'C' PARA ACESSAR O SEU CELULAR";
            }
            else if (i == 5)
            {
                text.text = "AO INTERAGIR COM OBJETOS PEGÁVEIS VOCÊ PODE MEXE-LO UTILIZANDO O MOUSE COM O BOTÃO ESQUERDO PRECIONADO";
            }
            else if (i > 6)
            {
                text.text = "";
            }

        }
    }

    void finishedTutorial()
    {
        if (CountPistas.instance.countEvidenciasAnalisadasOng >= CountPistas.instance.maxEvidenciasOng)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("rotinaFinal");
            }
        }
    }

    IEnumerator rotinaFinal()
    {
        // Lógica para o término do tutorial
        yield return null;
    }
}
