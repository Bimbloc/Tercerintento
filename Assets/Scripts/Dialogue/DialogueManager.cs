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

    //public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    [SerializeField]
    float textSpeed = 0.2f; //velocidad con la que se typean las letras
    int numDialogue; //n�mero del di�logo a leer

    //const string filePath = "/Resources/dialogue.txt";

    [TextArea(3, 10)] //ampliamos la cantidad de l�neas que pueden aparecer en el editor

    
    public string[] sentences; //array de frases de dialogo
    int numeroSentence = 0;

    static bool dialogueGoingOn; //bool con el prop�sito de que no se pueda pasar el juego si hay un di�logo


    private void Awake()
    {
        instance = this;
    }
    public static DialogueManager GetInstance() //Para conseguir la referencia a dialogue manager haciendo DialogueManager.getInstance()
    {
        return instance;
    }

    private void Start()
    {
        //dialogueBox.SetActive(false);

        dialogueText.text = "";

        //SetDialogue();

        //if (numDialogue == 0)
        //{
        //    StartDialogue();
        //}
    }

    private void SetDialogue()
    {
        string num = "Scene" + numDialogue.ToString();
        bool inDialogue = false;
        int i = 0;

        TextAsset textFile = Resources.Load<TextAsset>("dialogue");

        if (textFile != null)
        {
            StringReader dialogue = new StringReader(textFile.text);
            bool endOfFile = false;
            while (!endOfFile)
            {
                string s = dialogue.ReadLine();
                if (s == null)
                {
                    endOfFile = true;
                }
                else if (s == num)
                {
                    int numSentences = int.Parse(dialogue.ReadLine());
                    sentences = new string[numSentences];
                    inDialogue = true;
                }
                else if (inDialogue && s != "")
                {
                    sentences[i] = s;
                    i++;
                }
                else
                {
                    inDialogue = false;
                }
            }
            dialogue.Close();
        }
        else
            throw new Exception("Archivo de di�logo no encontrado");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) //si el jugador pulsa espacio
        {
            if (dialogueText.text == sentences[numeroSentence]) //y el texto ya se ha terminado de poner
            {
                NextSentence(); //pasa a la siguiente
            }
            else //si no ha terminado la l�nea de di�logo
            {
                StopAllCoroutines(); //para de escribir letra a letra
                dialogueText.text = sentences[numeroSentence]; //completa el texto
            }
        }
    }


    public void StartDialogue() //Para empezar el di�logo
    {
        if (sentences != null)
        {
            dialogueGoingOn = true;
            dialogueBox.SetActive(true); //se activa la caja de di�logo y se inicializa todo
            dialogueText.text = "";
            Time.timeScale = 0; //se pausa el juego
            numeroSentence = 0;
            StartCoroutine(TypeSentence()); //empieza a escribir la primera frase
        }
        else
        {
            Debug.LogWarningFormat("Di�logo de la escena {0} no encontrado.", numDialogue);
        }
    }
    IEnumerator TypeSentence() //Corutina para que el di�logo se muestre letra por letra
    {
        foreach (char c in sentences[numeroSentence]) //por cada letra en la frase
        {
            dialogueText.text += c; //se van sumando letras al texto
            if (numDialogue == 0 && (numeroSentence == 0 || numeroSentence == 1)) //est�tica
                dialogueText.color = Color.cyan;
            else
                dialogueText.color = Color.white;
            yield return new WaitForSecondsRealtime(textSpeed); //se espera en tiempo real para pasar a escribir la siguiente letra
        }
    }

    void NextSentence() //Para pasar a la siguiente l�nea del di�logo
    {
        if (numeroSentence < (sentences.Length - 1)) //si la frase todav�a est� dentro del array de frases
        {
            numeroSentence++; //pasa a la siguiente
            dialogueText.text = ""; //la caja de di�logo se pone sin texto
            StartCoroutine(TypeSentence()); //empieza a escribir la nueva frase
        }
        else //si ya no hay m�s frases
        {
            dialogueGoingOn = false;
            dialogueBox.SetActive(false); //se desactiva la caja de di�logo
            Time.timeScale = 1; //se quita la pausa

            //if (button != null)
            //{
            //    button.SetActiveButton();
            //}
        }
    }

    public bool DialogueGoing() //devuelve si hay un di�logo actuando o no
    {
        return dialogueGoingOn;
    }
}
