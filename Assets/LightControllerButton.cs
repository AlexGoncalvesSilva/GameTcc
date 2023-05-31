using UnityEngine;

public class LightControllerButton : MonoBehaviour
{
    private Light lightComponent;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    public void ToggleLight()
    {
        lightComponent.enabled = !lightComponent.enabled;
    }
}
