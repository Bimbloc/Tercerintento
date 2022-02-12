using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viento : MonoBehaviour
{
    [SerializeField]
    Vector3 direcctionViento;

    void Update()
    {
        transform.Translate(direcctionViento * Time.deltaTime);
    }
}
