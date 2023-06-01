using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    public AudioSource soundObjects;
    public AudioSource soundScenarioOng;
    public AudioSource soundScenarioLab;

    public float valorVolume;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        soundObjects.GetComponent<AudioSource>().volume = volumeSlider.value;
        soundScenarioOng.GetComponent<AudioSource>().volume = volumeSlider.value;
        soundScenarioLab.GetComponent<AudioSource>().volume = volumeSlider.value; 
        
        volumeSlider.value = PlayerPrefs.GetFloat("volume");

    }

    public void mudouVolume()
    {
        valorVolume = volumeSlider.value;

        PlayerPrefs.SetFloat("volume", valorVolume);

        Debug.Log("Valor: " + valorVolume);
    }
}
