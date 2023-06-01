using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValue : MonoBehaviour
{
    public Slider sliderV;

    // Start is called before the first frame update
    void Start()
    {
        float valorVolume = PlayerPrefs.GetFloat("volume");   
        sliderV.value = valorVolume;
        AudioListener.volume = valorVolume;
    }
}
