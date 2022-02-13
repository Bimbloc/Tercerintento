using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrar : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    AudioClip abrir, cerrar;

    AudioSource audioSource;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Abrir()
    {
        if (!anim.GetBool("Abierto"))
        {
            audioSource.clip = abrir;
            audioSource.Play();
        }
        anim.SetBool("Abierto", true);
    }

    public void Cerrar()
    {
        if (anim.GetBool("Abierto"))
        {
            audioSource.clip = cerrar;
            audioSource.Play();
        }
        anim.SetBool("Abierto", false);
    }
}
