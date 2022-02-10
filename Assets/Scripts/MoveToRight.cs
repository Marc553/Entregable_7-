using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : MonoBehaviour
{
    public float speed = 5f; //velocidad de movimiento 
    private int limite = 15; //limite de la pantalla 

    void Update()
    {
        //provoca el movimiento
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x > limite || transform.position.x < -limite)  //si se pasa de 15 o de -15 se destruye
        {
            Destroy(gameObject);
        }
    }
}
