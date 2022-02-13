using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEscena()
    {
        SceneManager.LoadScene("Javier");
    }

    public void correCompadre()
    {
        Application.Quit();
    }

    public void laHistoriaInterminable()
    {
        SceneManager.LoadScene("Creditos");
    }
}
