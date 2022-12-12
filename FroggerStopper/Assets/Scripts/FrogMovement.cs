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
    
    public bool moving;
    public int FrogSpeed = 1;

    // Pos and Pos2 are vector positions for the manholes. 
    // For example, the enemyprefab will be transported to this coordinate.  
    private Vector3 pos;
    private Vector3 pos2;

    // This holds an array of rigidbodies in the list with the same script as this one. 
    public Rigidbody2D[] enemyPrefabs;

     private int count;



    void Start()
    {
        
        moving = false;
        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.Find("GameController");

    }

    void Update()
    {
        if (moving == true)
        {   
            animator.SetBool("Jump", true);
        }

        if (moving == false)
        {
            animator.SetBool("Jump", false);
        }

    }
    public void TriggerFrogStart()
    {
        moving = true;
        StartCoroutine(Frogger());
        StartCoroutine(Lost());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car" && moving && collision.GetComponent<CarMovements>().getGo())
        {
            moving = false;
            GameController.GetComponent<MainGame>().RemoveFrog(gameObject);
            animator.SetBool("Jump", false);
            Destroy(gameObject);
        }
    }

    public IEnumerator Frogger()
    {

        while (moving)
        {
            rb.velocity = new Vector2(0, FrogSpeed);
            yield return new WaitForSeconds(2.0f);
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(1);
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
            
                GameController.GetComponent<MainGame>().showLosePanel();
                yield return null;
            }
        }
    }
}