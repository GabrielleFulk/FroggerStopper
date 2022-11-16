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
            if (randomNumber <= 3)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        }

            yield return new WaitForSeconds(2); 

        }
    }

    
  
 }
