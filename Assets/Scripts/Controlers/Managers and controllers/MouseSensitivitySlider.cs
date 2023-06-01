using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivitySlider : MonoBehaviour
{
    public Slider sensitivitySlider;
    public CameraController cameraController;

    void Start()
    {
        // Adicionar um listener para chamar o método ChangeMouseSensitivity quando o valor do slider for alterado
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    private void OnSensitivityChanged(float newSensitivity)
    {
        cameraController.ChangeMouseSensitivity(newSensitivity);
    }
}
