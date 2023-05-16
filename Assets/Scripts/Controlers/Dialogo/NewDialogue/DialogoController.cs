using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public GameObject painelDiaologo;

    public Text falaNPC;

    public GameObject resposta;

    public UnityEvent IsTalking;
    public UnityEvent OnFinishTalking;

    public bool falaAtiva = false;

    FalaNPC falas;

    public static DialogoController instance;

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
        if (Input.GetKeyDown(KeyCode.E) && falaAtiva)
        {
            if (falas.respostas.Length > 0) 
            {
                MostrarRespostas();
            }

            else
            {
                falaAtiva = false;
                painelDiaologo.SetActive(false);
                falaNPC.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                CameraController.instance.CanMoveCamera();
                OnFinishTalking.Invoke();
            }
        }
    }

    void MostrarRespostas() 
    {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for (int i = 0; i < falas.respostas.Length; i++) 
        {
            GameObject tempResposta = Instantiate(resposta, painelDiaologo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);
        }
    }

    public void ProximaFala(FalaNPC fala)
    {
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDiaologo.SetActive(true); 
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falas.fala;
    }

    void LimparRespostas() 
    {
        AnswerButton[] buttons = FindObjectsOfType<AnswerButton>();
        foreach (AnswerButton button in buttons)
        {
            Destroy(button.gameObject); 
        }
    }
}
