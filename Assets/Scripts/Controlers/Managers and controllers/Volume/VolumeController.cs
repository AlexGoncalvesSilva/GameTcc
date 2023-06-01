using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    // public AudioClip ongSound;
    // public AudioClip labSound;

    public AudioSource ongSound;
    public AudioSource labSound;

    public string sceneOffice; 
    public string sceneTut;
    public string sceneHouse;
    public string sceneONG;
    public string sceneLab;

    public GameObject soundOng;
    public GameObject soundLab;

    private AudioSource audioSource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneTut)
        {
            soundLab.SetActive(false);
            soundOng.SetActive(false);
        }
        if (scene.name == sceneOffice)
        {
            soundLab.SetActive(false);
            soundOng.SetActive(false);
        }
        if (scene.name == sceneHouse)
        {
            soundLab.SetActive(false);
            soundOng.SetActive(false);
        }
        if (scene.name == sceneONG)
        {
            soundLab.SetActive(false);
            soundOng.SetActive(true);
        }
        if (scene.name == sceneLab)
        {
            soundLab.SetActive(true);
            soundOng.SetActive(false);
        }

    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.Play();
    }

}
