using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed;
    public float rotation;
    public float gravity = -10f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    bool isGrounded;
    public  bool canMove = true; // Variável para controlar a movimentação do personagem

    public static PlayerMovement instance;

    private void Awake()
    {
        instance= this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (canMove) // Verifica se a movimentação está habilitada
        {
            movement();
        }
    }

    public void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); 
    }

    // Método para habilitar/desabilitar a movimentação do personagem
    public void SetCanMove(bool move)
    {
        canMove = move;
    }
}
