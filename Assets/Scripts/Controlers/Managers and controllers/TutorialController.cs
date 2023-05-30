using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Text text;
    public GameObject textFinal;
    public bool finished;

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
        if (i <= 5)
        {
            PlayerMovement.instance.canMove = false;
        }
        else { PlayerMovement.instance.canMove = true; }
        if (Input.GetKeyDown(KeyCode.E))
        {
            i += 1;
            if (i == 1)
            {
                text.text = "Para interagir com objetos e NPCs utilize o 'E'.";
            }
            else if (i == 2)
            {
                text.text = "Ao falar com os NPCs, utilize o mouse para selecionar a opção de resposta que você deseja.";
            }
            else if (i == 3)
            {
                text.text = "Para andar, utilize as teclas 'W, A, S, D'.";
            }
            else if (i == 4)
            {
                text.text = "Clique em 'ESC' para acessar as configurações.";
            }
            else if (i == 5)
            {
                text.text = "Ao interagir com objetos pegáveis, você pode movê-los utilizando o mouse com o botão esquerdo pressionado.";
            }
            else if (i > 6)
            {
                text.text = "";
            }

        }
    }

    void finishedTutorial()
    {
        if (CountPistas.instance.countEvidenciasAnalisadasCenario4 >= CountPistas.instance.maxEvidenciasCenario4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("rotinaFinal");
            }
        }
    }

    IEnumerator rotinaFinal()
    {
        yield return new WaitForSeconds(3f);
        textFinal.SetActive(true);
       
    }

}
