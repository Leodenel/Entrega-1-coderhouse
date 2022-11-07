using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{    
    float speed = 2f;

    void Update()

    {
        transform.Translate(0,0,-1.5f* Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.tag == "pared")
        {
          Destroy(gameObject);
        }
        if(col.transform.gameObject.tag == "jugador")
        {
            Destroy(gameObject);
        }
    }
    



}
