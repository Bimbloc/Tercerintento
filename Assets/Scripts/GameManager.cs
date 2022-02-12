using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject generatorNPC;

    [SerializeField] int caosTotal = 0;

    GameObject nowNPC;
    bool karmaNow;
    int caosNow;

    int pecadoresAlCielo;
    int pecadoresAlInfierno;
    int santosAlCielo;
    int santosAlInfierno;

    int dia;

    public string[] dia1;
    public string[] dia2;
    public string[] dia3;
    public string[] dia4;
    public string[] dia5;
    public string[] dia6;


    string[] diaActual;
    int clienteActual;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        { Destroy(this.gameObject); }
    }

    void Start()
    {
        dia = 1;
        setDay(dia1);
        clienteActual = 0;
        Invoke("nuevoCliente", 2.0f);
    }

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }


    void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void infoNPC(int c, bool b, GameObject NPC)
    {
        caosNow = c;
        karmaNow = b;
        nowNPC = NPC;
    }

    public void compruebaJuicio(bool b)
    {
        if (karmaNow == b)
        {
            caosTotal += caosNow;

            if (karmaNow)
                santosAlCielo++;
            else
                pecadoresAlInfierno++;
        }
        else
        {
            caosTotal -= caosNow;

            if (karmaNow)
                santosAlInfierno++;
            else
                pecadoresAlInfierno++;
        }
            
        generatorNPC.GetComponent<SpawnerNPC>().Clear();
        Destroy(nowNPC);

        clienteActual++;

        if (clienteActual != diaActual.Length)
        {
            if (diaActual[clienteActual] == "")
                Invoke("nuevoCliente", 2.0f);
            else
                Invoke("clienteEspecial", 2.0f);
        }
        else changeScene("endOfDay");
    }


    void nuevoCliente()
    {
        generatorNPC.GetComponent<SpawnerNPC>().NewNPC();
    }

    void clienteEspecial()
    {
        string s = diaActual[clienteActual];
        generatorNPC.GetComponent<SpawnerNPC>().NewSpecialNPC("Especiales/" + s, s);
    }

    public int[] endOfDayData()
    {
        if (caosTotal < 0) dia = 0;
        int[] array = { pecadoresAlCielo, pecadoresAlInfierno, santosAlCielo, santosAlInfierno, caosTotal, dia };
        return array;
    }

    public void SiguienteDia()
    {
        reset();

        dia++;

        switch (dia)
        {
            case(2):
                setDay(dia2);
                break;
            case (3):
                setDay(dia3);
                break;
            case (4):
                setDay(dia4);
                break;
            case (5):
                setDay(dia5);
                break;
            case (6):
                setDay(dia6);
                break;
            default:
                break;
        }

        changeScene("Rocio");

        Invoke("nuevoCliente", 2.0f);
    }

    private void reset()
    {
        pecadoresAlCielo = 0;
        pecadoresAlInfierno = 0;
        santosAlCielo = 0;
        santosAlInfierno = 0;

        caosTotal = 0;
        clienteActual = 0;
    }

    void setDay(string[] day)
    {
        diaActual = new string[day.Length];
        for (int i = 0; i < day.Length; i++)
            diaActual[i] = day[i];
    }

    public void setNPCGenerator(GameObject go)
    {
        generatorNPC = go;
    }
}
