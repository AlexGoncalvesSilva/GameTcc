using UnityEngine;

public class SwitcherOnOff : MonoBehaviour
{
    public GameObject associatedLight;
    public float distanciaMaxima = 3f;
    private bool lightOn = false;
    private Camera playerCamera;

    void Start()
    {
        associatedLight.SetActive(lightOn);
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaMaxima))
            {
                if (hit.collider.CompareTag("Switcher") && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Interruptor ativado!");
                    lightOn = !lightOn;
                    associatedLight.SetActive(lightOn);
                }
            }
        }
    }
}
