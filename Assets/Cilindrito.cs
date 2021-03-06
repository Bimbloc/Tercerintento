using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cilindrito : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t;
    Rigidbody rbody;
    //INPUT
    float vx = 0;
    bool vy = false;
    float vz = 0;
    new Vector3 direc;
    [SerializeField]
    float velocidad = 34;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetButton("X");
        vz = Input.GetAxis("Vertical");

        direc.x = vx;
        direc.y = 0;
        direc.z = vz;
    }

    void FixedUpdate()
    {
        vx = Input.GetAxis("Horizontal");
        vz = Input.GetAxis("Vertical");
        vy = Input.GetButton("Jump");
        direc.x = vx;
        if (vy)
            direc.y = 1;
        else
            direc.y = 0;
        direc.z = vz;
        rbody.velocity = direc * velocidad;
    }


    /*void OnCollisionEnter(Collision other)
    {
        Debug.Log("AAAAAAAA");
        Destroy(other.gameObject);
    }
    */

    void OnTriggerStay(Collider other)
    {
        Debug.Log("AAAA");
        t.localScale *= 1.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
