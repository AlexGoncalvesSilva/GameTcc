using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMenu : MonoBehaviour
{

    public GameObject Panel;
    public Transform PlayerCamera;
    [Header("MaxDistance")]
    public float MaxDistance = 5;

    private bool openedPanel = false;


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
                if (hit.transform.tag == "Car")
                {
                    if (!openedPanel)
                    {
                        openedPanel = true;
                        Panel.SetActive(true);
                    }
                    else
                    {
                        openedPanel = false;
                        Panel.SetActive(false);
                    }
                }
            }
            else
            {
                openedPanel = false;
                Panel.SetActive(false);
            }
        }

    }
    }
