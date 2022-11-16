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
    public Animator animator;
    
    private bool moving = true;
    //private float FrogSpeed = 0.005f;
    private int FrogSpeed = 1;


    void Start()
    {
        
        moving = true;
        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.Find("GameController");
    }

    void Update()
    {
        if (moving == true)
        {   
            animator.SetBool("Jump", true);
            Debug.Log("It's true");

        }

        if (moving == false)
        {
            animator.SetBool("Jump", false);
            Debug.Log("It's false");

        }

    }
    public void TriggerFrogStart()
    {
        StartCoroutine(Frogger());
        StartCoroutine(Lost());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car" && moving && collision.GetComponent<CarMovements>().getGo())
        {
            moving = false;
            //GameController.GetComponent<MainGame>().RemoveFrog(frogger);
            animator.SetBool("Jump", false);
            GetComponent<Renderer>().material.color = Color.red;
            Destroy(gameObject);
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