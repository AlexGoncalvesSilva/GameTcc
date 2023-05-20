using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    private float xRotation = 0f;
    public bool isViewingAnObject;
    public static CameraController instance;

    public Slider sensitivitySlider; // Referência ao slider de sensibilidade

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Carregar o valor salvo da sensibilidade do mouse
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 100f);
        sensitivitySlider.value = savedSensitivity; // Configurar o valor inicial do slider

        // Definir a sensibilidade do mouse com base no valor salvo
        ChangeMouseSensitivity(savedSensitivity);
    }

    void Update()
    {
        if (!isViewingAnObject)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivitySlider.value * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivitySlider.value * Time.fixedDeltaTime;

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
        PlayerPrefs.SetFloat("MouseSensitivity", newSensitivity); // Salvar o novo valor da sensibilidade do mouse
    }
}
