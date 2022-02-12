using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guion : MonoBehaviour
{
    public TextMeshProUGUI[] favores;
    public TextMeshProUGUI[] pecados;

    string[] guionbueno = { "accionbuena1", "accionbuen2", "accionbuena3", "accionbuena4" };
    string[] guionmalo = { "accionmala1", "accionmala2", "accionmala3" , "accionmala4" };

    public Npc.Cosabuena Cosabuenarandom(int i)
    {
        Npc.Cosabuena result= new Npc.Cosabuena();
        result.caos = 0;
        string d = guionbueno[Random.Range(0, guionmalo.Length)];
        result.dialogo = d;
        favores[i].text = d;
        return result;   
    }

    public Npc.Cosamala Cosamalarandom(int i)
    {
        Npc.Cosamala result = new Npc.Cosamala();
        result.caos = 0;
        string d = guionmalo[Random.Range(0, guionmalo.Length)];
        result.dialogo = d;
        pecados[i].text = d;
        return result;
    }
}
