using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrar : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void Abrir()
    {
        anim.SetBool("Abierto", true);
    }

    public void Cerrar()
    {
        anim.SetBool("Abierto", false);
    }
}
