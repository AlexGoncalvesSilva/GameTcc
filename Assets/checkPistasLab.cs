using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkPistasLab : MonoBehaviour
{
    public Button targetButton;

    public static checkPistasLab instance;

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
        
    }
    
    public void interactButton()
    {
        targetButton.interactable = true;
    }
}
