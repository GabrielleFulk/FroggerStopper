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
         StartCoroutine(Frogger());
    }

    IEnumerator Frogger()
    {   
        while(true)
        {
            randomNumber = Random.Range(0, 10);
            if (randomNumber <= 2)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        }

            yield return new WaitForSeconds(2); 

        }
    }

    
  
 }
