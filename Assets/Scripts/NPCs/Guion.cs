using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Guion : MonoBehaviour
{
    string filePath1 = "favores";
    string filePath2 = "pecados";

    public TextMeshProUGUI[] favores;
    public TextMeshProUGUI[] pecados;

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
        Npc.Cosabuena[] result = new Npc.Cosabuena[Random.Range(0, 4)];
        int i = 0;

        while (i < result.Length)
        {
            Npc.Cosabuena c = guionBueno[Random.Range(0, guionBueno.Length)];
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
        Npc.Cosamala[] result = new Npc.Cosamala[Random.Range(0, 4)];
        int i = 0;

        while (i < result.Length)
        {
            Npc.Cosamala c = guionMalo[Random.Range(0, guionMalo.Length)];
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
}
