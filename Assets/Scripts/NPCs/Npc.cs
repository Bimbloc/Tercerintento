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

    string path;

    MonoBehaviour d;


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
        int frase = Random.Range(0, 6);
        path = "NPCs/" + tipos[tipo] + "/" + tipos[tipo] + frase;
        d = dialogo;
        Debug.Log(path);
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.NewCharacter, new NewCharacterParams()
        {
            time = (int)(Time.time * 1000),
            type = tipo,
            sentence = frase,
        }));

        Debug.Log("Sentence: " + path);

        Invoke("StartDialoge", 2.0f);


        GetComponent<SpriteRenderer>().sprite = 
            contenedorsprites.GetComponent<Contenedorsprites>().generaAspectoRandom();

        Guion g = guion.GetComponent<Guion>();

        cosasmalas = g.Cosamalarandom();
        cosasbuenas = g.Cosabuenarandom();

        int caos = CalculaKarma();
        Tracker.Instance.TrackEvent(new TrackerEvent(EventType.CharacterSinner, new CharacterSinnerParams()
        {
            sinner = (caos >= 0) ? 1 : 0
        }));

        Debug.Log("Sinner: " + (caos >= 0));
        GameManager.GetInstance().infoNPC(Mathf.Abs(caos), caos >= 0, this.gameObject);

        GameManager.GetInstance().AddFinal(tipo, 1);
    }

    public void setSpecialNPC(MonoBehaviour contenedorsprites, MonoBehaviour guion, MonoBehaviour dialogo,
        string dialogePath, string spritePath)
    {
        path = dialogePath;
        d = dialogo;

        Invoke("StartDialoge", 2.0f);

        
        GetComponent<SpriteRenderer>().sprite =
            contenedorsprites.GetComponent<Contenedorsprites>().getEspecialASpect(spritePath);

        GameManager.GetInstance().infoNPC(0, true, this.gameObject);
    }

    void StartDialoge()
    {
        d.GetComponent<DialogueManager>().startDialogue(path);
    }
}
