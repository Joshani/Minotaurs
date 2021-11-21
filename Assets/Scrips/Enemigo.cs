using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    void Start()
    {

    }

   
    void Update()
    {

    }
    // Usamos la funcion collision para que cuando mi jugador toque al enemigo pierda.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") { 
            collision.gameObject.SetActive(false);
        }
    }
}