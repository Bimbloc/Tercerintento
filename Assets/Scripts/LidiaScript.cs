using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidiaScript : MonoBehaviour
{
    Transform t;
    Rigidbody rBody;
    float vx = 0; //direccion horizontal
    float vy = 0;//direccion vertical
    new Vector3 direc;

    [SerializeField]
    float velocidad = 3;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
        direc.x = vx;
        direc.y = vy;
        t = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        vx = Input.GetAxis("Horizontal");
        vy= Input.GetAxis("Vertical");
       // vz = Input.GetAxis("Jump");
        direc.x = vx;
        direc.y = vy;
        rBody.velocity = direc * velocidad;
    }
    /*
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("AAAAA");
        Destroy(other.gameObject);
        
    }

    void OnColissionExit()
    {

    }*/
    void OnTriggerStay(Collider other)
    {
        Debug.Log("AAAAA");

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAA");

        t.localScale *= 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
