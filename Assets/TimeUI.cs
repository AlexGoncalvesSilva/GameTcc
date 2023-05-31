using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    public TGSky timeController; // Referência ao script TGSky
    public TextMeshProUGUI timeText; // Referência ao objeto TextMeshProUGUI da UI que exibirá as horas e minutos

    private void Start()
    {
        UpdateTimeUI();
    }

    private void Update()
    {
        UpdateTimeUI();
    }

    private void UpdateTimeUI()
    {
        int currentHour = Mathf.FloorToInt(timeController.hour); // Obtém a hora atual do script TGSky
        int currentMinute = Mathf.FloorToInt((timeController.hour - currentHour) * 60); // Obtém os minutos atuais
        timeText.text = currentHour.ToString("D2") + ":" + currentMinute.ToString("D2"); // Atualiza o texto da UI com a hora e minutos formatados
    }
}
