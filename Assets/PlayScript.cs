using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
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
