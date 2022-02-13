using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    RectTransform rectTransform;
    public Vector3 speed;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
    }

    private void Update()
    {
        rectTransform.localPosition += speed * Time.deltaTime;
    }

    public void Decelerar()
    {
        speed.y -= 10;
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Nico 1");
    }
}
