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
        anim.SetBool("Abierto", true);
        audioSource.clip = abrir;
        audioSource.Play();
    }

    public void Cerrar()
    {
        anim.SetBool("Abierto", false);
        audioSource.clip = cerrar;
        audioSource.Play();
    }
}
