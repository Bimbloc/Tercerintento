using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnerNPC : MonoBehaviour
{
    public MonoBehaviour guion;
    public MonoBehaviour contenedorSprites;
    public MonoBehaviour dialogo; //referencia al canvas

    public AbrirCerrar libro; //para abrir cerrar el libro

    public GameObject npc; //prefab

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.GetInstance().setNPCGenerator(this.gameObject);
    }

    public void NewNPC()
    {
        //SendEvent("NPCAppeared", Time.time * 1000);
        Debug.Log("NPCAppeared: " + Time.time * 1000);

        libro.Abrir();
        GameObject go = Instantiate<GameObject>(npc, transform.position, transform.rotation);
        go.GetComponent<Npc>().setData(contenedorSprites, guion, dialogo);
    }

    public void NewSpecialNPC(string dp, string tp)
    {
        libro.Cerrar();
        GameObject go = Instantiate<GameObject>(npc, transform.position, transform.rotation);
        go.GetComponent<Npc>().setSpecialNPC(contenedorSprites, guion, dialogo, dp, tp);
    }

    public void VieneEspecial()
    {
        libro.Cerrar();
    }

    public void Clear()
    {
        guion.GetComponent<Guion>().Clear();
    }
}
