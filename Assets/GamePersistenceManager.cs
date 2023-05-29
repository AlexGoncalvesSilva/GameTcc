using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphonePersistenceManager : MonoBehaviour
{
    private void Awake()
    {
        // Verificar se o celular já foi coletado
        if (PlayerPrefs.HasKey("CellphoneCollected") && PlayerPrefs.GetInt("CellphoneCollected") == 1)
        {
            GameObject cellphoneOnTable = GameObject.Find("CellphoneOnTable");
            if (cellphoneOnTable != null)
            {
                cellphoneOnTable.SetActive(false); // Desativa o telefone da mesa em todas as cenas
            }
        }
    }
}
