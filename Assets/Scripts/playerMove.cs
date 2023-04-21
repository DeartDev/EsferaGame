using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMove : MonoBehaviour
{

    public Rigidbody rb;
    public float velocidad = 2000;
    public float desplazamiento = 2000;
    public Text puntaje;
    

    void Start()
    {
        Debug.Log("Hola, mundo!");

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce( 0, 0, velocidad * Time.deltaTime);

        if(Input.GetKey("d") || Input.GetKey("s"))
        {
            rb.AddForce(desplazamiento * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("a") || Input.GetKey("w"))
        {
            rb.AddForce(-desplazamiento * Time.deltaTime, 0, 0);
        }

        // puntaje.text = transform.position.(z*(-1)).ToString("0");
        
    }
}
