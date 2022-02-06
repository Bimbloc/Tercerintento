using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lauracubo : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t;
    Rigidbody rb;
    // INPUT
    float vx = 0;
    float vy = 0;
    float dz = 0;
    bool vz = false;
    new Vector3 direc;
    [SerializeField] // Permite modificar en Unity
    float velocidad = 34;
    // Sólo usar int en interfaces, el resto float
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        vx = Input.GetAxis("Horizontal"); // Q eje
        vy = Input.GetAxis("Vertical"); // Devuelve un número
        // Una forma
        // direc = new Vector3(vx, vy, 0); // Es un vector
        // Otra forma mejor
        direc.x = vx;
        direc.y = vy;
    }
    void FixedUpdate()
    { //x,y,z estamos en un espacio tridimensional
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
        vz = Input.GetButton("Jump"); // Devuelve si está pulsado o no
        if (vz)
        {
            dz = 1;
        }
        else
            dz = 0;

        direc.x = vx;
        direc.y = vy;
        direc.z = dz;
        rb.velocity = direc * velocidad;
        //Debug.Log(vz);
        /*if (vx > -0.001 && vx < 0.001) // Esto es por los gamepads q no funcionan igual q los teclados cuando se ha parado de presionar
        {
            // Otra forma para q no frene de golpe
            if (rb.velocity.x > 0.5)
                rb.velocity = rb.velocity - new Vector3(0.5f, 0, 0);
            else if (rb.velocity.x < -0.5)
            {
                rb.velocity = rb.velocity + new Vector3(0.5f, 0, 0);
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }
        else
            rb.AddForce(new Vector3(1, 0, 0) * vx * velocidad);
        */
    }
    /*
    void OnCollisionEnter(Collision other) //Si pones Collider other es distinto
    {
        Debug.Log("AAAAAAAAAAAA"); // escribe en pantalla
        Destroy(other.gameObject); // other es una referencia con el objeto q te chocas

    }
    */
    /*
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("AAAAAAAAAAAA"); // escribe en pantalla
        Destroy(other.gameObject); // other es una referencia con el objeto q te chocas

    }
    */
    // Triggers (tiene exit o stay (si está en esa zona))
    void OnTriggerStay(Collider other)
    {
        Debug.Log("AAAAAAAAAAAA");

        t.localScale *= 1.1f; // Cambia el tamaño (mejor hacerlo en un OnTriggerEnter porque sino da error porque se hace muy grande)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
