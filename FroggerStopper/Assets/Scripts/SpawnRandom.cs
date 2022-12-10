using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class SpawnRandom : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private int randomNumber;
    private Rigidbody2D rb;
   

    void Start()
    {
         randomNumber = Random.Range(0, 1000);
         StartCoroutine(Frogger());
    }

    IEnumerator Frogger()
    {   
        while(true)
        {
            randomNumber = Random.Range(0, 10);
            if (randomNumber <= 10)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("red");
            yield return new WaitForSeconds(0.5f); 
            GetComponent<Renderer>().material.color = Color.white;
            Debug.Log("white");


        }
            randomNumber = Random.Range(0, 10);

            yield return new WaitForSeconds(3); 

        }
    }

    
  
 }
