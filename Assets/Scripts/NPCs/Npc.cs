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

    int numcosasbuenas;
    int numcosasmalas;
    // enum Tipo {normal,profefdi,furro,capitalista,satanico };
    string[] tipos = { "normal", "profefdi", "furro", "capitalista", "satanico" };
    struct Cosabuena { 
        public
        string dialogo; 
        public
        int caos; 
    
    };
    struct Cosamala {
        public
        string dialogo; 
        public
        int caos; 
    };
   // Sprite[] aspectoposible;
    Cosamala[] cosasmalas;
    Cosabuena[] cosasbuenas;
    //string[] paparsearstructs= { };
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
       // Debug.Log(paparsearstructs);
        //Debug.Log(c);
        // Debug.Log(c.Cosasmalasrandom("furro", 2));//danull
       // c.Cosasmalasrandom("furro", 1);
       //paparsearstructs= c.Cosasmalasrandom("furro", 1);

        //for (int i = 0; i < paparsearstructs.Length; i++)
        //{
          //  Debug.Log(paparsearstructs[i]);
        //}
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
