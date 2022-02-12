using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
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

    private int CalculaKarma()
    {
        int karma = 0;

        for (int i = 0; i < cosasbuenas.Length; i++)
            karma += cosasbuenas[i].caos;

        for (int i = 0; i < cosasmalas.Length; i++)
            karma -= cosasmalas[i].caos;

        return karma;
    }

    public void setData(MonoBehaviour contenedorsprites, MonoBehaviour guion, MonoBehaviour dialogo)
    {
        tipo = Random.Range(0, tipos.Length);
        string path = "NPCs/" + tipos[tipo] + "/" + tipos[tipo] + Random.Range(0, tipos.Length);      
        dialogo.GetComponent<DialogueManager>().startDialogue(path);
        Debug.Log(path);


        GetComponent<SpriteRenderer>().sprite = 
            contenedorsprites.GetComponent<Contenedorsprites>().generaAspectoRandom();

        Guion g = guion.GetComponent<Guion>();

        cosasmalas = g.Cosamalarandom();
        cosasbuenas = g.Cosabuenarandom();

        int caos = CalculaKarma();
        GameManager.GetInstance().infoNPC(Mathf.Abs(caos), caos >= 0, this.gameObject);
    }

    public void setSpecialNPC(MonoBehaviour contenedorsprites, MonoBehaviour guion, MonoBehaviour dialogo,
        string dialogePath, string spritePath)
    {
        dialogo.GetComponent<DialogueManager>().startDialogue(dialogePath);
        GetComponent<SpriteRenderer>().sprite =
            contenedorsprites.GetComponent<Contenedorsprites>().getEspecialASpect(spritePath);

        GameManager.GetInstance().infoNPC(0, true, this.gameObject);
    }
}
