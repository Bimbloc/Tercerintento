using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNPC : MonoBehaviour
{
    public MonoBehaviour guion;
    public MonoBehaviour contenedorSprites;
    public MonoBehaviour dialogo;

    public GameObject npc;
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.GetInstance().setNPCGenerator(this.gameObject);
    }

    public void NewNPC()
    {
        GameObject go = Instantiate<GameObject>(npc, transform.position, transform.rotation);
        go.GetComponent<Npc>().setData(contenedorSprites, guion, dialogo);
    }

    public void NewSpecialNPC(string dp, string tp)
    {
        GameObject go = Instantiate<GameObject>(npc, transform.position, transform.rotation);
        go.GetComponent<Npc>().setSpecialNPC(contenedorSprites, guion, dialogo, dp, tp);
    }

    public void Clear()
    {
        guion.GetComponent<Guion>().Clear();
    }
}
