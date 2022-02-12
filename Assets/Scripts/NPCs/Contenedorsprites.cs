using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedorsprites : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] aspectogeneral= new Sprite[2] ;
    Sprite jsj;
    void Start()
    {
        aspectogeneral[0] = Resources.Load<Sprite>("npcsad");
        aspectogeneral[1] = Resources.Load<Sprite>("npcsad.2png");
        jsj = Resources.Load<Sprite>("npcsad");
        
        Debug.Log(jsj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Sprite generaAspectoRandom()
    {
        int selected = Random.Range(0, aspectogeneral.Length);

        return aspectogeneral[selected];
        //return jsj ;
    }
}
