using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEndOfDay : MonoBehaviour
{
    public GameObject nextDayButton;
    public GameObject loseButton;

    public TextMeshProUGUI[] text;

    private void Start()
    {
        int[] array = GameManager.GetInstance().endOfDayData();
        int i;
        for (i = 0; i < text.Length - 1; i++)
            text[i].text = "" + array[i];

        if (array[i] > 0)
        {
            text[i].text = "Día " + array[i] + " Completado";
            nextDayButton.SetActive(true);
            loseButton.SetActive(false);
        }
            
        else
        {
            text[i].text = "Derrota: Jesucristo te Castigará";
            nextDayButton.SetActive(false);
            loseButton.SetActive(true);
        }
    }

    public void NextDayButton()
    {
        GameManager.GetInstance().SiguienteDia();
    }
}
