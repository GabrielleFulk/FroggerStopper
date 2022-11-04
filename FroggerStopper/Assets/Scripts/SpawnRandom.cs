using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class SpawnRandom : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private int randomNumber;
   

    void Start()
    {
         randomNumber = Random.Range(0, 1000);
         Debug.Log(randomNumber);
    }

    void Update()
    {
        if (randomNumber <= 40)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
        
        randomNumber = Random.Range(0, 1000);
        Debug.Log("Trial:" + randomNumber);
    }

    
  
 }
