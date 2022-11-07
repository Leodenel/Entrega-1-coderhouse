using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CANON : MonoBehaviour
{
    public GameObject objetoAInstanciar;
    public Transform posJugador;    
    public Transform spawnPos;
    public AudioSource _disparo;
    float time;


 
    void Start()
    {
        time = 1;
    }


    void Update()
    {
        RepeticionBala();
        MirarAlJugador();
    }

    private void RepeticionBala()
    {
        time -= Time.deltaTime;
        if(time <=0)
        {
            float dist = Vector3.Distance(posJugador.position , transform.position);
            if(dist <= 7)
            Instantiate(objetoAInstanciar, spawnPos.position, spawnPos.rotation);
            time = 1.5f;
                       
            
        }
    }

    void MirarAlJugador()
    {
        transform.LookAt(posJugador);
    }



}
