using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedorsprites : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] aspectogeneral = new Sprite[6];

    void Start()
    {
        aspectogeneral[0] = Resources.Load<Sprite>("Sprites/npc1");
        aspectogeneral[1] = Resources.Load<Sprite>("Sprites/npc2");
        aspectogeneral[2] = Resources.Load<Sprite>("Sprites/npc3");
        aspectogeneral[3] = Resources.Load<Sprite>("Sprites/npc4");
        aspectogeneral[4] = Resources.Load<Sprite>("Sprites/Abuela4");
        aspectogeneral[5] = Resources.Load<Sprite>("Sprites/Abuela5");
    }

    public Sprite generaAspectoRandom()
    {
        return aspectogeneral[Random.Range(0, aspectogeneral.Length)];
    }

    public Sprite getEspecialASpect(string path)
    {
        return Resources.Load<Sprite>("Sprites/Especial/" + path);
    }
}
