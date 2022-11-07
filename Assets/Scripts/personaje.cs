using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    public Transform posJugador;
    public Animator anim;
    public AudioSource pasos;
    public int vidas = 5;
    float llaves = 0;

    void start()
    {      
        Debug.Log(vidas);
        Debug.Log(llaves);           
    }

    void Update()
    {
        MovimientoJugador();
    }

    void damage()
    {        
        vidas = vidas - 1;
        Debug.Log("vidas restantes " + vidas);
    }

    void MovimientoJugador()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,1.5f*Time.deltaTime);
            anim.SetBool("estaCorriendo", true);
            if(Input.GetKeyDown(KeyCode.W))
            {
            pasos.Play();
            }
        }

        
        if(Input.GetKeyUp(KeyCode.W))
        {
         anim.SetBool("estaCorriendo", false);
         pasos.Pause();   
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-0.5f*Time.deltaTime);
            anim.SetBool("caminarAtras", true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("caminarAtras", false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-120*Time.deltaTime,0);
        }
         
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,120*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0,2*Time.deltaTime,0);
        }

        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.tag == "Llave")
        {
          Destroy(col.transform.gameObject);
            llaves = llaves + 1;
            Debug.Log("usted tiene " + llaves + " llaves");
        }        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.name == "Porton")
        {
            if(llaves >= 3)
            {
                Destroy(col.transform.gameObject);
                llaves = 0;
                vidas = vidas + 1;
                Debug.Log("vidas " + vidas);
                Debug.Log("todas las llaves fueron usadas");
            }
            if(llaves < 3)
            {
                Debug.Log("necesita 3 llaves para abrir este porton");
            }
        }
        if(col.transform.gameObject.tag == "bala")
        {            
        damage();
        if(vidas <= 0)
        Destroy(gameObject);
        }

    }


}
