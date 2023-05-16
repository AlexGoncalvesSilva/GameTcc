using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    private float xRotation = 0f;
    public bool isViewingAnObject;
    public static CameraController instance;

    public Slider sensitivitySlider; // Referência ao slider de sensibilidade
    private float mouseSensitivity = 100f; // Sensibilidade inicial do mouse

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Configurar o valor inicial do slider para a sensibilidade atual
        sensitivitySlider.value = mouseSensitivity;
    }

    void Update()
    {
        if (!isViewingAnObject)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void CanMoveCamera()
    {
        isViewingAnObject = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void CantMoveCamera()
    {
        isViewingAnObject = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ChangeMouseSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}
