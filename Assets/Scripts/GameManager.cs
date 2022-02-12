using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int caosglobal = 0;
    private int maxcaos = 32;
    private int maxcat = 8;
    private int numclientesprocesados=0;//cada x random viene uno especial
    private int numdia=0;
    int[] cantidadestiposnpcs = new int[5];
    public enum tiposnpcs {normal,profedsi,furro,capitalista,satanico };
    
    //Singleton
    void Awake()
    {
        //cantidadestiposnpcs[(int)tiposnpcs.furro] = 0;
     
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        { Destroy(this.gameObject); }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

}
