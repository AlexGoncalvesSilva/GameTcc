using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Vector3 minPosition; // Posi��o m�nima do limite da �rea
    public Vector3 maxPosition; // Posi��o m�xima do limite da �rea
    public float moveSpeed = 2f; // Velocidade de movimento do animal
    public float raycastDistance = 1f; // Dist�ncia do Raycast para verificar paredes
    public LayerMask wallLayer; // Layer das paredes

    private Vector3 targetPosition; // Posi��o alvo atual do animal

    private void Start()
    {
        // Define uma posi��o alvo inicial dentro dos limites da �rea
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        // Movimenta o animal em dire��o � posi��o alvo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verifica se o animal chegou � posi��o alvo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Define uma nova posi��o alvo dentro dos limites da �rea
            targetPosition = GetRandomPosition();
        }

        // Verifica se h� uma parede em frente ao animal
        if (CheckWallAhead())
        {
            // Se h� uma parede, gira o animal em uma nova dire��o contr�ria � parede
            Vector3 newDirection = Quaternion.Euler(0f, 90f, 0f) * (targetPosition - transform.position).normalized;
            targetPosition = transform.position + newDirection;
        }

        // Orienta o objeto em dire��o � posi��o alvo
        transform.LookAt(targetPosition);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }

    // Obt�m uma posi��o aleat�ria dentro dos limites da �rea
    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            transform.position.y,
            Random.Range(minPosition.z, maxPosition.z)
        );

        return randomPosition;
    }

    // Verifica se h� uma parede em frente ao animal
    private bool CheckWallAhead()
    {
        Vector3 raycastOrigin = transform.position + transform.forward * raycastDistance;
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin, transform.forward, out hit, raycastDistance, wallLayer))
        {
            // H� uma parede em frente ao animal
            return true;
        }

        // N�o h� parede em frente ao animal
        return false;
    }
}