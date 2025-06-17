using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Guion : MonoBehaviour
{
    string filePath1 = "favores";
    string filePath2 = "pecados";

    public TextMeshPro[] favores;
    public TextMeshPro[] pecados;

    Npc.Cosabuena[] guionBueno;
    Npc.Cosamala[] guionMalo;

    private void Awake()
    {
        StringReader archivo = new StringReader(Resources.Load<TextAsset>(filePath1).text);    
        guionBueno = new Npc.Cosabuena[int.Parse(archivo.ReadLine())];
        
        string s = archivo.ReadLine();
        int i = 0;
        while (s != null)
        {
            string[] array = s.Split('_');
            guionBueno[i].caos = int.Parse(array[0]);
            guionBueno[i].texto = array[1];
            i++;
            s = archivo.ReadLine();
        }

        archivo.Close();

        archivo = new StringReader(Resources.Load<TextAsset>(filePath2).text);
        guionMalo = new Npc.Cosamala[int.Parse(archivo.ReadLine())];

        s = archivo.ReadLine();
        i = 0;
        while (s != null)
        {
            string[] array = s.Split('_');
            guionMalo[i].caos = int.Parse(array[0]);
            guionMalo[i].texto = array[1];
            i++;
            s = archivo.ReadLine();
        }

        archivo.Close();
    }

    public Npc.Cosabuena[] Cosabuenarandom()
    {
        Npc.Cosabuena[] result = new Npc.Cosabuena[Random.Range(1, 4)];
        int i = 0;

        while (i < result.Length)
        {
            int random = Random.Range(0, guionBueno.Length);
            Npc.Cosabuena c = guionBueno[random];
            Tracker.Instance.TrackEvent(new TrackerEvent(EventType.NewFavor, new NewFavorParams(){favor = random}));
            int j = 0;
            while (j < i && c.texto != result[j].texto)
                j++;

            if (j == i)
            {
                result[i] = c;
                favores[i].text = c.texto;
                i++;
            }
        }

        return result;   
    }

    public Npc.Cosamala[] Cosamalarandom()
    {
        Npc.Cosamala[] result = new Npc.Cosamala[Random.Range(1, 4)];
        int i = 0;

        while (i < result.Length)
        {
            int random = Random.Range(0, guionMalo.Length);
            Npc.Cosamala c = guionMalo[random];
            Tracker.Instance.TrackEvent(new TrackerEvent(EventType.NewSin, new NewSinParams() {sin = random}));
            int j = 0;
            while (j < i && c.texto != result[j].texto)
                j++;

            if (j == i)
            {
                result[i] = c;
                pecados[i].text = c.texto;
                i++;
            }
        }

        return result;
    }

    public void Clear()
    {
        for (int i = 0; i < favores.Length; i++)
            favores[i].text = "";

        for (int i = 0; i < pecados.Length; i++)
            pecados[i].text = "";

    }
}
