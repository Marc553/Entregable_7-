using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] objectsPrefabs; //conjunto de objetos(bomba/recolectable)
    private Vector3 SpawnPosition; //vector de spawn de los objetos 

    //variables del randomrange
    private float yRangeUp = 14f;  //altura max
    private float yRangeDown = 1f; //altura min
    private int valor0 = 0; 
    private int valor2 = 2;
   private float valorX = -13.5f; //valores de los extremos X
    private float giro = 180; //grio que efectuan los GO del lado derecho


    //varaibels RandomRange
    private float randomY;  //altura random
    private int randomIdex; //object seleccionado random
    private float lado; //num random


    //varaibles del invoke
    private float startTmie = 2;
    private float repeatRate = 1.5f;
    private PalyerController PlayerController;


    void Start()
    {
        PlayerController = GameObject.Find("Player").GetComponent<PalyerController>();

        InvokeRepeating("SpawnObjects", startTmie, repeatRate);  //llama al spawnobject
    }

    public Vector3 RandomSpawnPosition()
    {
        randomY = Random.Range(yRangeDown, yRangeUp); //me da el valor random de la altura
        return new Vector3(valorX, randomY, 0); //posicion que usará el spwanobject
    } 


    public void SpawnObjects()
    {
        if(!PlayerController.gameOver)
        {
            randomIdex = Random.Range(0, objectsPrefabs.Length); //numero entre 0 y maximo numero d objetos d mi "objectsPrefabs"
        SpawnPosition = RandomSpawnPosition(); //posicion del spawn
        lado = Random.Range(valor0, valor2); //decide numero entre 0 y 2 para decir si sale por la derecha o la izquerda
        if (lado == valor0)
        {
          Instantiate(objectsPrefabs[randomIdex], SpawnPosition, objectsPrefabs[randomIdex].transform.rotation); //si sale por la izquierda sale de forma normal
        }
        else
        { 
            SpawnPosition.x = SpawnPosition.x * -1;  //primero lo cambio de lado
          Quaternion rotation = Quaternion.Euler(transform.rotation.x, giro, transform.rotation.z);  //creo la variable que lo gire 180º
          Instantiate(objectsPrefabs[randomIdex], SpawnPosition, rotation);  //lo instancia en el lado contrario y girado 180º
        }

        }
        
        
    }



}
