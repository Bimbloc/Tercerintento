using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Contenedoracciones : MonoBehaviour
{
    // Start is called before the first frame update
    //buenas acciones
    string[] cosasbuenasgeneral = { "goodgeneral" };
    string[] cosasbuenasfurros = { "goodfurros" };
    string[] cosasbuenasprofesfdi = { "goodprofesfdi" };
    string[] cosasbuenassatanicos = { "goodsatanicos" };
    string[] cosasbuenascapitalistas = { "goodcapitalistas" };
    //malas acciones
    string[] cosasmalasgeneral = { "badgeneral"};
    string[] cosasmalasfurros = { "badfurros" };
    string[] cosasmalasprofesfdi = { "badprofesfdi" };
    string[] cosasmalassatanicos = { "badsatanicos" };
    string[] cosasmalascapitalistas = { "badcapitalistas" };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   string[] Cosasbuenasrandom(string tipo,int num)
    {
        //HABRA REPETICIONES DE COSAS PORQUE C# NO TIENE VECTORES
         string[] selector= { };
        string[] resultado = { };
   
        switch (tipo) {

            case "normal":
                selector = cosasbuenasgeneral;
                break;
            case "profefdi":
                selector = cosasbuenasprofesfdi;
                break;
            case "furro":
                selector = cosasbuenasfurros;
                break;
            case "capitalista":
                selector = cosasbuenascapitalistas;
                break;
            case "satanico":
                selector = cosasbuenassatanicos;
                break;


        }
        int cont = 0;
        int selected= Random.Range(0, num);
        while (selector.Length != 0 || cont < num)
        {

            resultado[cont] = selector[selected];
            
        
        }
        return resultado;
        
    }
    string[] Cosasmalasrandom(string tipo, int num)
    {
        //HABRA REPETICIONES DE COSAS PORQUE C# NO TIENE VECTORES
        string[] selector = { };
        string[] resultado = { };

        switch (tipo)
        {

            case "normal":
                selector = cosasmalasgeneral;
                break;
            case "profefdi":
                selector = cosasmalasprofesfdi;
                break;
            case "furro":
                selector = cosasmalasfurros;
                break;
            case "capitalista":
                selector = cosasmalascapitalistas;
                break;
            case "satanico":
                selector = cosasmalassatanicos;
                break;


        }
        int cont = 0;
        int selected = Random.Range(0, num);
        while (selector.Length != 0 || cont < num)
        {

            resultado[cont] = selector[selected];


        }
        return resultado;

    }
}
