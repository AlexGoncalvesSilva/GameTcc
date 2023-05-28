using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Vector3 minPosition; // Posição mínima do limite da área
    public Vector3 maxPosition; // Posição máxima do limite da área
    public float moveSpeed = 2f; // Velocidade de movimento do animal
    public float raycastDistance = 1f; // Distância do Raycast para verificar paredes
    public LayerMask wallLayer; // Layer das paredes

    private Vector3 targetPosition; // Posição alvo atual do animal

    private void Start()
    {
        // Define uma posição alvo inicial dentro dos limites da área
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        // Movimenta o animal em direção à posição alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verifica se o animal chegou à posição alvo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Define uma nova posição alvo dentro dos limites da área
            targetPosition = GetRandomPosition();
        }

        // Verifica se há uma parede em frente ao animal
        if (CheckWallAhead())
        {
            // Se há uma parede, gira o animal em uma nova direção contrária à parede
            Vector3 newDirection = Quaternion.Euler(0f, 90f, 0f) * (targetPosition - transform.position).normalized;
            targetPosition = transform.position + newDirection;
        }

        // Orienta o objeto em direção à posição alvo
        transform.LookAt(targetPosition);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }

    // Obtém uma posição aleatória dentro dos limites da área
    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            transform.position.y,
            Random.Range(minPosition.z, maxPosition.z)
        );

        return randomPosition;
    }

    // Verifica se há uma parede em frente ao animal
    private bool CheckWallAhead()
    {
        Vector3 raycastOrigin = transform.position + transform.forward * raycastDistance;
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin, transform.forward, out hit, raycastDistance, wallLayer))
        {
            // Há uma parede em frente ao animal
            return true;
        }

        // Não há parede em frente ao animal
        return false;
    }
}