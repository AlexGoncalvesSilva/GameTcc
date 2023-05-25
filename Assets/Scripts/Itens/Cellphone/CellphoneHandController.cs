using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneHandController : MonoBehaviour
{
    private bool activatedCellphone = false;
    private GameObject cellphoneHandObject;
    private GameObject cellphoneLightObject;

    private void Start()
    {
        cellphoneHandObject = gameObject;
        cellphoneLightObject = transform.GetChild(0).gameObject; // Supondo que a luz do celular é um filho do objeto da mão
        SetCellphoneState(CellphoneManager.Instance.IsCellphoneCollected());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (activatedCellphone)
            {
                SetCellphoneState(false);
            }
            else
            {
                SetCellphoneState(true);
            }
        }
    }

    private void SetCellphoneState(bool state)
    {
        activatedCellphone = state;
        cellphoneHandObject.SetActive(state);
        cellphoneLightObject.SetActive(state);
    }
}
