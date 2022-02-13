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

    //"Normal", "Furro", "Capitalista", "Satanico"
    [SerializeField] int[] finales;
    int finalNow;
    int incrementoNow;

    bool esEspecial;

    int time;

    private void Start()
    {
        resetGame();
    }

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

    public void startGame()
    {
        changeScene("Javier");
        resetGame();
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
        if (!esEspecial)
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
                    pecadoresAlCielo++;
            }
        }

        if (b) finales[finalNow] += incrementoNow;

        generatorNPC.GetComponent<SpawnerNPC>().Clear();

        Destroy(nowNPC, 5);

        clienteActual++;

        if (clienteActual != diaActual.Length)
        {
            generaCliente();
        }
        else changeScene("endOfDay");
    }


    void nuevoCliente()
    {
        Debug.Log("nuevo cliente");
        generatorNPC.GetComponent<SpawnerNPC>().NewNPC();
    }

    void generaCliente()
    {
       
        if (diaActual[clienteActual] == "")
        {           
            esEspecial = false;
            Invoke("nuevoCliente", time);
        }
        else
        {
            esEspecial = true;
<<<<<<< HEAD
            Invoke("clienteEspecial", time);
=======
            Invoke("clienteEspecial", 5.0f);
            generatorNPC.GetComponent<SpawnerNPC>().VieneEspecial();
>>>>>>> 402266b41aa6465cb95bb855cd7591c89adf78a2
        }
            
    }

    void clienteEspecial()
    {
        string[] array = diaActual[clienteActual].Split('_');
        AddFinal(int.Parse(array[1]), 20);
        generatorNPC.GetComponent<SpawnerNPC>().NewSpecialNPC("Especiales/" + array[0], array[0]);
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
            case (2):
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

        if (dia < 7)
        {
            changeScene("Javier");
            time = 1;
            generaCliente();
            time = 5;
        }
        else
        {
            // changeScene("endOfGame");
            pasaAlfinal();

        }


        
    }

    void resetGame()
    {

        reset();

        finales = new int[4];
        dia = 1;
        setDay(dia1);
        clienteActual = 0;
        time = 1;
        generaCliente();
        time = 5;
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
        Debug.Log("npcGenerator seteado");
        generatorNPC = go;
    }

    public void AddFinal(int i, int cant)
    {
        finalNow = i;
        incrementoNow = cant;
    }

    public string determinarFinal()
    {
        int i = 0;
        int max = 0;

        for (int j = 0; j < finales.Length; j++)
        {
            if (finales[j] > max)
            {
                max = finales[j];
                i = j;
            }
        }

        switch (i)
        {
            case (0):
                return "EndingBueno";
                break;
            case (1):
                return "EndingFurro";
                break;
            case (2):
                return "EndingCapitalista";
                break;
            case (3):
                return "EndingSatanico";
                break;
            default:
                break;
        }

        return "";

    }
    void pasaAlfinal()
    {
        string finalito;
        finalito = determinarFinal();
        changeScene(finalito);
    
    
    }

    public GameObject GetNowNPC()
    {
        return nowNPC;
    }

    public void GoToMenu()
    {    
        changeScene("Nico 1");
        DestroyImmediate(this.gameObject, true);
    }

    public void loseScene()
    {
        changeScene("Endingmale");
    }
}
