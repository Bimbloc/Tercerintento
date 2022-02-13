using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEndOfDay : MonoBehaviour
{
    public GameObject nextDayButton;
    public GameObject loseButton;

    public GameObject libro;

    public TextMeshPro[] text;

    private void Start()
    {
        int[] array = GameManager.GetInstance().endOfDayData();
        int i;
        for (i = 0; i < text.Length - 1; i++)
            text[i].text = "" + array[i];

        if (array[i] > 0)
        {
            text[i].text = "Día " + array[i];
            nextDayButton.SetActive(true);
            loseButton.SetActive(false);
        }
            
        else
        {
            text[i].text = "Derrota";
            nextDayButton.SetActive(false);
            loseButton.SetActive(true);
        }

        libro.GetComponent<AbrirCerrar>().Abrir();
    }

    public void NextDayButton()
    {
        GameManager.GetInstance().SiguienteDia();
    }
}
