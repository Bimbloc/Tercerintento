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
    enum Tipo {normal,profefdi,furro,capitalista,satanico };
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
    
    int caostotal;
    void Start()
    {
        aspecto = GetComponent<SpriteRenderer>();
        
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
