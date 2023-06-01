using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedController : MonoBehaviour
{
    public bool finishedGame;

    public static GameFinishedController instance;

    public string targetSceneName; // Nome da cena que você deseja verificar

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


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
        if (scene.name == targetSceneName)
        {
            // A cena alvo foi carregada, faça o que for necessário aqui
            Debug.Log("Cena " + targetSceneName + " carregada!");
            PlayFinal.instance.playFinal();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
