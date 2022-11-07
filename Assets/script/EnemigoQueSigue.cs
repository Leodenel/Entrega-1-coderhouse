using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoQueSigue : MonoBehaviour
{
    public Transform posJugador;

    void Update()
    {
        DistanciaDelJugador();
    }
    void DistanciaDelJugador()
    {
        float dist = Vector3.Distance(posJugador.position , transform.position);
        if(dist > 2)
        transform.position = Vector3.MoveTowards(transform.position, posJugador.position , Time.deltaTime);
       

        

    }
}

