using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip oficina;
    public AudioClip jeffrey;
    public AudioClip terrare;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void JeffreyStart()
    {
        audioSource.clip = jeffrey;
        audioSource.Play();
    }

    public void TerrrareStart()
    {
        audioSource.clip = terrare;
        audioSource.Play();
    }

    public void TerminaEvento()
    {
        audioSource.clip = oficina;
        audioSource.Play();
    }
}
