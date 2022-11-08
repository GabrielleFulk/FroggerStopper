using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogMovement : MonoBehaviour
{
    // This will be the enemy Avatar
    public GameObject frogger;
    private Rigidbody2D rb;
    public GameObject GameController;
    // Start is called before the first frame update
    
    public bool moving;
    public float FrogSpeed;


    void Start()
    {
        
        moving = true;
        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.Find("GameController");
        //StartCoroutine(Frogger());
    }

    void Update()
    {
        

    }
    public void TriggerFrogStart()
    {
        
        StartCoroutine(Frogger());
        StartCoroutine(Lost());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car" && moving)
        {
            moving = false;
            GameController.GetComponent<MainGame>().RemoveFrog(gameObject);
            
            GetComponent<Renderer>().material.color = Color.red;
            
            
           

        }
    }

    public IEnumerator Frogger()
    {

        while (moving)
        {
            Debug.Log("On");

            rb.velocity = new Vector2(0, FrogSpeed);
            yield return new WaitForSeconds(0.8f);
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(1);
            Debug.Log("off");


        }
        
        
            yield return null;
        

    }
    private IEnumerator Lost()
    {
        
        while (true)
        {
            if (gameObject.transform.position.y <= 5)
            {
                yield return new WaitForSeconds(.5f);
            }
            else {
            
                SceneManager.LoadScene("LostScene");// FIX AND REPLACE WITH RESTET UI
                yield return null;
            }
        }
    }
}