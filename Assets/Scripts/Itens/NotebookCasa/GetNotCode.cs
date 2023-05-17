using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GetNotCode : MonoBehaviour
{

    public Transform PlayerCamera;
    [Header("MaxDistance")]
    public float MaxDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, MaxDistance))
            {
                if (hit.transform.tag == "BobTheDog")
                {
                    CheckPassword.instance.playerGetThePassword = true; 
                    Debug.Log("Pegou a senha");
                }
            }
            else {}
        }
    }

}
