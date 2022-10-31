using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    // This will be the enemy Avatar
    public GameObject frogger;
    // Start is called before the first frame update
    private float speed = 0.005f;
    private float enemyTimeScale = 0.70f;
    public bool MoveDown;

     void Update() {
 
        Frogger();
         
    }

    public void Frogger()
    {
        Vector3 transformDown = transform.up * 1.0f;
        Vector3 transformPause = transform.up * 0.0f;
        for (int index = 0; index < 100; index++)
        {
            for (int j = 0; j < 1000; j++)
            {

              if((j == 80))
                {
                    transform.Translate(transformDown * speed * enemyTimeScale); 
                    Debug.Log("J:" + j);
                }
            else 
            {
                transform.Translate(transformPause * 0.0f * enemyTimeScale);
            }
        
            }
        }
        
    }





} 


