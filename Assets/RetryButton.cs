using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryDay()
    {
        GameManager.GetInstance().setCaos(0);
        //GameManager.GetInstance().dia--;
        GameManager.GetInstance().SiguienteDia();
        GameManager.GetInstance().changeScene("Javier");

    }
}
