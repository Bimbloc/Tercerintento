using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTuMenu : MonoBehaviour
{
    public void sexo()
    {
        GameManager.GetInstance().GoToMenu();
        Debug.Log("hola");
    }
}
