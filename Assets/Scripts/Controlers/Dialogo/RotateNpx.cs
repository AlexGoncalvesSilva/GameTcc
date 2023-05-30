using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateNpx : MonoBehaviour
{
    public Transform player;
    private Quaternion initialRotation;
    public bool isRotating = false;

    public static RotateNpx instance;
    
    private void Awake()
    {
        instance = this;
        initialRotation = transform.rotation;
    }

    private void Start()
    {
        // Salva a rotação inicial do objeto
    
    }
    
    private void Update()
    {
        if (isRotating)
        {
            // Calcula a direção para o jogador
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // Mantém o objeto no mesmo plano horizontal que o jogador

            // Calcula a rotação para olhar na direção do jogador
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Interpola suavemente a rotação do objeto para a nova rotação
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        if(isRotating == false) { transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * 5f); }
    }

    public void Interact()
    {
        // Ativa a rotação para o jogador
        isRotating = true;
        
    }
    
    public void ResetRotation()
    {
        // Desativa a rotação para o jogador
        isRotating = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * 5f);

    }
}