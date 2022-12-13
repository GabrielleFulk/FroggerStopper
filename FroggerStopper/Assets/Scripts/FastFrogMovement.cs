using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastFrogMovement : MonoBehaviour
{
    public GameObject frogger;
    private Rigidbody2D rb;
    public GameObject GameController;
    public Animator animator;

    // Pos and Pos2 are vector positions for the manholes. 
    // For example, the enemyprefab will be transported to this coordinate.  
    private Vector3 pos;
    private Vector3 pos2;

    // This holds an array of rigidbodies in the list with the same script as this one. 
    public Rigidbody2D[] enemyPrefabs;

    // This is an array of two spawnpoints for enemy spawn.
    public GameObject spawnOne;
    public GameObject spawnTwo;

    private int count;
    private bool moving;

    private float xPos1;
    private float yPos1;

    private float xPos2;
    private float yPos2;



    private int FrogSpeed = 1;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.Find("GameController");
       
        // You can change to the coordinate accordingly
        float xPos1 = spawnOne.transform.position.x;
        float yPos1 = spawnOne.transform.position.y;

        float xPos2 = spawnTwo.transform.position.x;
        float yPos2 = spawnTwo.transform.position.y;


        pos = new Vector3(xPos1,yPos1,0);
        pos2 = new Vector3(xPos2,yPos2,0);
        Debug.Log("Postiton 1: " + pos);
        Debug.Log("Position 2:" + pos2);
        count = 0;
        
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
        
        if (-5.3 <= transform.position.y && transform.position.y <=-4.13)
            {
                    count = count + 1;
                    Debug.Log("Count: " + count);
                    if (count % 2 == 1)
                        transform.position = pos;
                    if (count % 2 == 0)
                        transform.position = pos;
                    
               
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
            Debug.Log("Distance: " + rb.position.y);
            yield return new WaitForSeconds(1.6f);
            rb.velocity = new Vector2(0, 0);

            yield return new WaitForSeconds(2);
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
            else
            {

                GameController.GetComponent<MainGame>().showLosePanel();
                yield return null;
            }
        }
    }
}
