using UnityEngine;

public class OnOffStreetlights : MonoBehaviour
{
    public TGSky skyController;
    public GameObject lightsObject;

    private void Update()
    {
        bool isNightActive = skyController.isNight;

        if (isNightActive)
        {
            lightsObject.SetActive(true);
        }
        else
        {
            lightsObject.SetActive(false);
        }
    }
}
