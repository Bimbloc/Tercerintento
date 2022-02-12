using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Start is called before the first frame update
    Npc.Cosamala cosamala;
    Npc.Cosabuena cosabuena;
    string[] guionbueno= {"accionbuena" };
    string[] guionmalo= { "accionmala"};
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Npc.Cosabuena Cosabuenarandom()
    {
        Npc.Cosabuena result= new Npc.Cosabuena();
        int c = Random.Range(-8,-1);
        int selected = Random.Range(0, guionmalo.Length);
        result.caos = c;
        result.dialogo = guionmalo[selected];
        return result;
    
    
    
    }
    public Npc.Cosamala Cosamalarandom()
    {
        Npc.Cosamala result = new Npc.Cosamala();
        int c = Random.Range(1, 8);
        int selected = Random.Range(0, guionmalo.Length);
        result.caos = c;
        result.dialogo = guionbueno[selected];
        return result;



    }
}
