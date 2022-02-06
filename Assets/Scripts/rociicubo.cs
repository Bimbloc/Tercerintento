using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rociicubo : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    //INPUT
    float vx = 0;
    float vy = 0;
    float dz=0;
   bool vz = false;
    new Vector3 direc;
    [SerializeField]
    float velocidad = 34;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
        direc.x = vx;
        direc.y = vy;
    }
    void FixedUpdate()
    {//x,y,z
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");
         vz= Input.GetButton("Jump");
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
