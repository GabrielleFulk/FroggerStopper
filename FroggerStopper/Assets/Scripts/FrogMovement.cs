using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    // This will be the enemy Avatar
    public GameObject frogger;
    // Start is called before the first frame update
    private float speed = 0.009f;
    private float enemyTimeScale = 0.8f;
    public bool moving;

     void Start() {
        moving = false;
        StartCoroutine(Frogger());
    }

    void Update()
    {
        if (moving)
            transform.Translate(transform.up* speed * enemyTimeScale);

    }


    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            moving = false;
            
            transform.Translate(transform.up* speed * 0.0f);
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.8f);
            Destroy(gameObject);
        
        }
    }

    IEnumerator Frogger()
    {   

        while(true)
        {
             moving = false;
             yield return new WaitForSeconds(1); 
             moving = true;
             yield return new WaitForSeconds(0.8f);



    }
 } 
}
