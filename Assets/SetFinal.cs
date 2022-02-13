using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetFinal : MonoBehaviour
{
    public TextMeshProUGUI final;

    void Start()
    {
        final.text = "Final " + GameManager.GetInstance().determinarFinal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
