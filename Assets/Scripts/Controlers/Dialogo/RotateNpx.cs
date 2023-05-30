using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNpx : MonoBehaviour
{
    public Transform player;
    private Quaternion initialRotation;
    private bool isRotating = false;

    public static RotateNpx instance;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Salva a rota��o inicial do objeto
        initialRotation = transform.rotation;
    }
    
    private void Update()
    {
        if (isRotating)
        {
            // Calcula a dire��o para o jogador
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // Mant�m o objeto no mesmo plano horizontal que o jogador

            // Calcula a rota��o para olhar na dire��o do jogador
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Interpola suavemente a rota��o do objeto para a nova rota��o
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        else
        {
            // Retorna � rota��o inicial
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * 5f);
           
            
        }
    }

    public void Interact()
    {
        // Ativa a rota��o para o jogador
        isRotating = true;
    }
    
    public void ResetRotation()
    {
        // Desativa a rota��o para o jogador
        isRotating = false;

    }
}