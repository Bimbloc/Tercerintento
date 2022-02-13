using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    Transform t;
    Rigidbody rb;
    //INPUT
    float vx = 0;
    float vy = 0;
    float dz = 0;
    bool vz = false;
    new Vector3 direc;
    [SerializeField]
    float velocidad = 34;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
        direc.x = vx;
        direc.y = vy;
    }
    void FixedUpdate()
    {//x,y,z
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
        vz = Input.GetButton("Jump");
        if (vz)
        { dz = 1; }
        else
            dz = 0;

        direc.x = vx;
        direc.y = vy;
        direc.z = dz;
        rb.velocity = direc * velocidad;
        /// Debug.Log(vz);
        /*if (vx > -0.001 && vx < 0.001)
        {
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
            rb.AddForce(new Vector3(1, 0, 0) * vx * velocidad);*/


    }
    /* void OnCollisionEnter(Collision other)
     {
         Debug.Log("AAAAAAAAAAAA");
         Destroy(other.gameObject);

     }*/
    //Triggers
    void OnTriggerStay(Collider other)
    {
        Debug.Log("AAAAAAAAAAAA");

        if (t.localScale.x > 10)
        {
            t.localScale *= 0.91f;
        }
        else if (t.localScale.x <= 10)
        {
            t.localScale *= 1.1f;
        }


    }
    // Update is called once per frame
    void Update()
    {

    }
}
