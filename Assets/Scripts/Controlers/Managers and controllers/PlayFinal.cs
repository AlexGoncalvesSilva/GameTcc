using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFinal : MonoBehaviour
{

    public GameObject videoPlayer;
    public GameObject imageJornal;
    public GameObject mira;

    public bool canClose;

    public GameObject feedback;

    public static PlayFinal instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canClose && Input.GetKeyDown(KeyCode.E))
        {
            mira.SetActive(true);
            imageJornal.SetActive(false);
            feedback.SetActive(false);
            canClose = false;
        }
    }

    public void playFinal()
    {
        StartCoroutine("rotinaVideo");
    }

    IEnumerator rotinaVideo()
    {
        yield return new WaitForSeconds(0.5f);
        mira.SetActive(false);
        videoPlayer.SetActive(true);
        StartCoroutine("rotinaImage");
    }

    IEnumerator rotinaImage()
    {
        yield return new WaitForSeconds(17.5f);
        videoPlayer.SetActive(false);
        imageJornal.SetActive(true);
        feedback.SetActive(true );
        canClose = true;

    }
}
