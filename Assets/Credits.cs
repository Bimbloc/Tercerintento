using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    RectTransform recto;
    public Vector2 velocidad;

    void Start()
    {
        recto = GetComponent<RectTransform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        recto.anchoredPosition.y += velocidad * Time.deltaTime;
    }

}
