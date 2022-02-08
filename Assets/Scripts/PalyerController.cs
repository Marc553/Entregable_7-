using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerController : MonoBehaviour
{
    public float playerSpeed = 20f; //velocidad con la que se empuja la player
    private Rigidbody playerRigidbody;  //rigidbody del player 
    private float yRange = 0.23f; //limite del suelo donde se acaba el juego 
   
   
    public int recolectables = 0; //numero de recolectables recogidos
    
    
    private AudioSource playerAudioSource; //ruido que se escucahara al efectuar el salto
    public AudioClip boingClip;
    public AudioClip blipClip;
    public AudioClip boomClip;

    public ParticleSystem particleRecolectable;
    public ParticleSystem particleExprosion;
 

    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>(); //entra en la componente rigidbody del player 
        playerAudioSource = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        //Ejecuta la acción de ejercer fuerza cuando se pulsa el espacio 
        if (Input.GetKey(KeyCode.Space)) 
        {
            playerRigidbody.AddForce(Vector3.up * playerSpeed); //fuerza ejercida al player hacia arriba
            playerAudioSource.PlayOneShot(boingClip, 1);
        }

        //Si el player pasa esta posición el juego se acaba (es el suelo)
        if (transform.position.y < yRange) 
        {
            Time.timeScale = 0;
        }

    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        //Si se choca con el objeto con la etiqueta llamada "recolectable" suma 1 al recolectable
        if(otherCollider.gameObject.CompareTag("recolectable"))
        {
            recolectables++;
            Debug.Log(recolectables);
           //playerAudioSource.PlayOneShot(boingClip, 1);
        }

        if(otherCollider.gameObject.CompareTag("ground"))
        {
            Debug.Log("funciono");
        }
    
        /*if(otherCollider.gameObject.CompareTag("bomba"))
        {
           playerAudioSource.PlayerOneShot(boomClip, 1);
           Time.timeScale = 0;
           
        }*/
    }



}
