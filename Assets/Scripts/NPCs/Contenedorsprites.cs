using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedorsprites : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] aspectogeneral= new Sprite[2] ;

    void Start()
    {
        aspectogeneral[0] = Resources.Load<Sprite>("Sprites/npcsad");
        aspectogeneral[1] = Resources.Load<Sprite>("Sprites/npcsad.2png");
    }

    public Sprite generaAspectoRandom()
    {
        return aspectogeneral[Random.Range(0, aspectogeneral.Length)];
    }
}
