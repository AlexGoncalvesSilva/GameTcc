using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneMenuController : MonoBehaviour
{

    private bool activatedCellphone = false;
    public GameObject cellphoneObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            activatedCellphone = !activatedCellphone;

            if (cellphoneObj)
            {
                cellphoneObj.SetActive(activatedCellphone);
            }
        }
    }
}