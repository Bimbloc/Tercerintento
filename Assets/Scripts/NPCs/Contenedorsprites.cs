using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedorsprites : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] aspectogeneral;
    void Start()
    {
        aspectogeneral[0] = Resources.Load<Sprite>("sadnpc");
        aspectogeneral[1] = Resources.Load<Sprite>("captura");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Sprite generaAspectoRandom()
    {
        int selected = Random.Range(0, 2);

        return aspectogeneral[selected];
    }
}
