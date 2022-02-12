using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    MonoBehaviour contenedorsprites;
    MonoBehaviour guion;
    MonoBehaviour dialogo;

    public string[] tipos = { "Normal", "Furro", "Capitalista", "Satanico" };
    public int maxDialogosTipo = 4;
    int tipo;
    
    public struct Cosabuena {
        public string texto;
        public int caos;
    };
    public struct Cosamala {
        public string texto;
        public int caos;
    };
    
    Cosamala[] cosasmalas;
    Cosabuena[] cosasbuenas;

    int caostotal;

    void Calculacaos()
    {
        int ct=0;
        for (int i = 0; i < cosasmalas.Length; i++)
        {
            ct += cosasmalas[i].caos;
        
        }
        for (int i = 0; i < cosasbuenas.Length; i++)
        {
            ct += cosasbuenas[i].caos;
        }
        caostotal = ct;
    }

    public void setData(MonoBehaviour contenedorsprites_, MonoBehaviour guion_, MonoBehaviour dialogo_)
    {
        dialogo = dialogo_;
        contenedorsprites = contenedorsprites_;
        guion = guion_;

        tipo = Random.Range(0, tipos.Length);
        string path = "NPCs/" + tipos[tipo] + "/" + tipos[tipo] + Random.Range(0, tipos.Length);      
        dialogo_.GetComponent<DialogueManager>().startDialogue(path);
        Debug.Log(path);


        GetComponent<SpriteRenderer>().sprite = 
            contenedorsprites.GetComponent<Contenedorsprites>().generaAspectoRandom();

        Guion g = guion.GetComponent<Guion>();

        cosasmalas = g.Cosamalarandom();
        cosasbuenas = g.Cosabuenarandom();
    }
}
