using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneManager : MonoBehaviour
{
    private static CellphoneManager instance;

    public static CellphoneManager Instance
    {
        get { return instance; }
    }

    private bool cellphoneCollected = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool IsCellphoneCollected()
    {
        return cellphoneCollected;
    }

    public void SetCellphoneCollected(bool collected)
    {
        cellphoneCollected = collected;
    }
}
