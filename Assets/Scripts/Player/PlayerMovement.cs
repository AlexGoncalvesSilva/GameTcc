using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // velocidade de movimento do personagem
    public float rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        movement();
    }

    public void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0, y) * moveSpeed;

        transform.Translate(dir * Time.deltaTime);

        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));
    }

}
