using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    public float playerSpeed = 20f; //velocidad con la que se empuja la player
    private Rigidbody playerRigidbody;  //rigidbody del player 
    private float yRange = 14;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * playerSpeed); //fuerza ejercida al player hacia arriba
        }

        //if (transform.position.y > yRange)
        {
            
        }

    }
}
