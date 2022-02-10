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
    public AudioClip boingClip; //audio salto 
    public AudioClip blipClip;  //audio recolectale
    public AudioClip boomClip;  //audio explosión 

    public ParticleSystem particleRecolectable;  //particulas recolectable
    public ParticleSystem particleExprosion;  //particulas explosión

    public bool gameOver;
 

    void Start()
    {
           
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>(); //entra en la componente rigidbody del player 
        playerAudioSource = GetComponent<AudioSource>(); //entra en la componente audio source del player
    }

  
    void Update()
    {
        if(!gameOver)
        { 
            //Ejecuta la acción de ejercer fuerza cuando se pulsa el espacio 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerRigidbody.AddForce(Vector3.up * playerSpeed,ForceMode.Impulse); //fuerza ejercida al player hacia arriba
            playerAudioSource.PlayOneShot(boingClip, 1); //reproduce una vez el audio de salto 
        }

        }
         
        //Si el player pasa esta posición el juego se acaba (es el suelo)
        if (transform.position.y < yRange) 
        {
            gameOver = true;
        }

        if(gameOver)
        {
            
        }
       

    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(!gameOver)
        { 
            //Si se choca con el objeto con la etiqueta llamada "recolectable" suma 1 al recolectable y reproduce el audio de recolectable
        if(otherCollider.gameObject.CompareTag("recolectable"))
        {
            recolectables++;
           playerAudioSource.PlayOneShot(blipClip, 1);
            particleRecolectable.Play();
            Destroy(otherCollider.gameObject);
        }
     
        // Si se choca con el objetocon la etiqueta llamada "exprosion" reproduce el audio de explosion y acaba el juego 
        if(otherCollider.gameObject.CompareTag("exprosion"))
        {
           playerAudioSource.PlayOneShot(boomClip, 1);
            particleExprosion.Play();
            Destroy(otherCollider.gameObject);
            gameOver = true;
           
        }

        }

        
        
    }

    



}
