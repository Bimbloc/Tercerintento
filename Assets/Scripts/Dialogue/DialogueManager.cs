using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public GameObject mainButton;
    TextMeshProUGUI dialogueText;

    public GameObject button1;
    public GameObject button2;

    public GameObject heavenButton;
    public GameObject hellButton;

    [SerializeField]
    float textSpeed = 0.2f; //velocidad con la que se typean las letras

    struct sentece
    {
        public int obj;
        public int dest;
        public string text;
    }

    struct option
    {
        public string opt1;
        public string opt2;

        public int dest1;
        public int dest2;

        public int obj;
    }
  
    sentece[] sentences; //array de frases de dialogo
    sentece nowWritting;

    option[] options;
    option nowOptions;

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance() //Para conseguir la referencia a dialogue manager haciendo DialogueManager.getInstance()
    {
        return instance;
    }

    public void startDialogue(string filePath)
    {
        dialogueText = mainButton.GetComponentInChildren<TextMeshProUGUI>();
        dialogueText.text = "";

        mainButton.SetActive(true);

        button1.SetActive(false);
        button2.SetActive(false);

        heavenButton.SetActive(false);
        hellButton.SetActive(false);

        SetDialogue(filePath);
        StartDialogue();
    }

    private void SetDialogue(string filePath)
    {
        TextAsset textFile = Resources.Load<TextAsset>(filePath);

        if (textFile != null)
        {          
            StringReader dialogue = new StringReader(textFile.text);
            sentences = new sentece[int.Parse(dialogue.ReadLine())];
            options = new option[int.Parse(dialogue.ReadLine())];

            int i = 0;
            int j = 0;

            string s = dialogue.ReadLine();

            while (s != null)
            {
                string[] array = s.Split('_');

                int obj_ = int.Parse(array[0]);

                if (obj_ >= 0)
                {
                    sentences[i].obj = obj_;
                    sentences[i].dest = int.Parse(array[1]);
                    sentences[i].text = array[2];
                    i++;
                }
                else
                {
                    options[j].obj = obj_;
                    options[j].dest1 = int.Parse(array[1]);
                    options[j].opt1 = array[2];
                    options[j].dest2 = int.Parse(array[3]);
                    options[j].opt2 = array[4];
                    j++;
                }                
                
                s = dialogue.ReadLine();
            }
            dialogue.Close();
        }
        else
            throw new Exception("Archivo de diálogo no encontrado");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) //si el jugador pulsa espacio
        {
            DialogeClicked();
        }
    }

    public void StartDialogue() //Para empezar el diálogo
    {
        mainButton.SetActive(true); //se activa la caja de diálogo y se inicializa todo
        dialogueText.text = "";
        nowWritting = sentences[0];
        StartCoroutine(TypeSentence()); //empieza a escribir la primera frase
    }

    IEnumerator TypeSentence() //Corutina para que el diálogo se muestre letra por letra
    {
        foreach (char c in nowWritting.text) //por cada letra en la frase
        {
            dialogueText.text += c; //se van sumando letras al texto
            yield return new WaitForSecondsRealtime(textSpeed); //se espera en tiempo real para pasar a escribir la siguiente letra
        }
    }

    void NextSentence() //Para pasar a la siguiente línea del diálogo
    {
        int dest = nowWritting.dest;
        if (dest > 0) //si la frase todavía está dentro del array de frases
        {
            int i = 0;
            while (dest != sentences[i].obj)
                i++;

            nowWritting = sentences[i];
            dialogueText.text = ""; //la caja de diálogo se pone sin texto

            StartCoroutine(TypeSentence()); //empieza a escribir la nueva frase
        }
        else if  (dest < 0) {
            int i = 0;
            while (dest != options[i].obj)
                i++;

            nowOptions = options[i];
            button1.GetComponentInChildren<TextMeshProUGUI>().text = nowOptions.opt1;
            button2.GetComponentInChildren<TextMeshProUGUI>().text = nowOptions.opt2;

            button1.SetActive(true);
            button2.SetActive(true);
        }     
        else
        {
            heavenButton.SetActive(true);
            hellButton.SetActive(true);
        }
    }

    public void OptionClicked(bool b)
    {
        int dest;
        if (b) dest = nowOptions.dest1;
        else dest = nowOptions.dest2;

        int i = 0;
        while (dest != sentences[i].obj)
            i++;

        button1.SetActive(false);
        button2.SetActive(false);

        nowWritting = sentences[i];
        dialogueText.text = "";

        StartCoroutine(TypeSentence()); 
    }

    public void DialogeClicked()
    {
        if (dialogueText.text == nowWritting.text) //y el texto ya se ha terminado de poner
        {
            NextSentence(); //pasa a la siguiente
        }
        else //si no ha terminado la línea de diálogo
        {
            StopAllCoroutines(); //para de escribir letra a letra
            dialogueText.text = nowWritting.text; //completa el texto
        }
    }

    public void GoToHeaven(bool b)
    {
        GameManager.GetInstance().compruebaJuicio(b);

        mainButton.SetActive(false);
        heavenButton.SetActive(false);
        hellButton.SetActive(false);
    }
}
