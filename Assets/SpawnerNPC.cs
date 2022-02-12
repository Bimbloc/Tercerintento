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
    void Start()
    {
        GameObject go = Instantiate<GameObject>(npc, transform.position, transform.rotation);
        go.GetComponent<Npc>().setData(contenedorSprites, guion, dialogo);
    }
}
