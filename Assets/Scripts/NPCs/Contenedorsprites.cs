using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedorsprites : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite[] aspectogeneral = new Sprite[15];

    void Start()
    {
        aspectogeneral[0] = Resources.Load<Sprite>("Sprites/npc1");
        aspectogeneral[1] = Resources.Load<Sprite>("Sprites/npc2");
        aspectogeneral[2] = Resources.Load<Sprite>("Sprites/npc3");
        aspectogeneral[3] = Resources.Load<Sprite>("Sprites/npc4");
        aspectogeneral[4] = Resources.Load<Sprite>("Sprites/npc7");
        aspectogeneral[5] = Resources.Load<Sprite>("Sprites/npc8");
        aspectogeneral[6] = Resources.Load<Sprite>("Sprites/npc9");
        aspectogeneral[7] = Resources.Load<Sprite>("Sprites/npc10");
        aspectogeneral[8] = Resources.Load<Sprite>("Sprites/npc11");
        aspectogeneral[9] = Resources.Load<Sprite>("Sprites/npc12");
        aspectogeneral[10] = Resources.Load<Sprite>("Sprites/npc13");
        aspectogeneral[11] = Resources.Load<Sprite>("Sprites/npc14");
        aspectogeneral[12] = Resources.Load<Sprite>("Sprites/npc15");
        aspectogeneral[13] = Resources.Load<Sprite>("Sprites/npc16");
        aspectogeneral[14] = Resources.Load<Sprite>("Sprites/Abuela5");
    }

    public Sprite generaAspectoRandom()
    {
        int n = Random.Range(0, aspectogeneral.Length);
        //SendEvent("NPCSpriteID", aspectogeneral[n]);
        Debug.Log("NPCSpriteID: " + aspectogeneral[n]);
        return aspectogeneral[n];
    }

    public Sprite getEspecialASpect(string path)
    {
        return Resources.Load<Sprite>("Sprites/Especial/" + path);
    }
}
