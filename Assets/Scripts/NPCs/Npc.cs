using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer aspecto;
    [SerializeField]
    int maxcosasbuenas;
    [SerializeField]
    int maxcosasmalas;
    [SerializeField]
    MonoBehaviour contenedorsprites;
    [SerializeField]
    MonoBehaviour contenedoracciones;
    [SerializeField]
    MonoBehaviour guion;
    int numcosasbuenas;
    int numcosasmalas;
    // enum Tipo {normal,profefdi,furro,capitalista,satanico };

    string[] tipos = { "normal", "profefdi", "furro", "capitalista", "satanico" };
    public struct Cosabuena {
        public string texto;
        public int caos;
    };
    public struct Cosamala {
        public string texto;
        public int caos;
    };
    // Sprite[] aspectoposible;
   
    
    Cosamala[] cosasmalas;
    Cosabuena[] cosasbuenas;

    string hola;
    string adios;
    int caostotal;
    void Start()
    {
        aspecto = GetComponent<SpriteRenderer>();
        Contenedoracciones c = contenedoracciones.GetComponent<Contenedoracciones>();
        hola = c.Holasrandom("furro");
        adios= c.Adiosrandom("furro");
        Debug.Log(hola);
        Debug.Log(adios);

        Contenedorsprites s = contenedorsprites.GetComponent<Contenedorsprites>();
        aspecto.sprite = s.generaAspectoRandom();
        Debug.Log(s.generaAspectoRandom());
        //Debug.Log(guion.GetComponent<Guion>());
        Guion g = guion.GetComponent<Guion>();

        cosasmalas = g.Cosamalarandom();
        cosasbuenas = g.Cosabuenarandom();

        
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
