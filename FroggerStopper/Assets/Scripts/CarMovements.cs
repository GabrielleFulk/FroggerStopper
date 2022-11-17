using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CarMovements : MonoBehaviour
{
    public float carSpeed;
    private Rigidbody2D rb;
    private GameObject carStopper;
    public int points;
    public Sprite carImage;

    private bool snap;
    private Collider2D slot;
    private bool move;
    private bool go;
    public bool awake;
    private SpriteRenderer sprite; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        carStopper = GameObject.Find("CarStopper");
        move = true;
        snap = false;
        go = false;
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (awake){
            sprite.color = new Color(1f, 1f, 1f, 1f);
            sprite.transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
        }
        else
        {
            sprite.color = new Color(1f, 1f, 1f, .8f);
            sprite.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        }
        //if (snap && !move && !go)
        //{
          //  transform.position = slot.transform.position;
        //}
       // if (!move & !snap && !go) Destroy(gameObject);
        //if (move) transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }

    public void TriggerCarStart()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
        go = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "CarStopper")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "slot")
        {
            snap = true;
            slot = collider;
            Debug.Log("ontrigger enter car");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot")
        {
            snap = false;
            slot = null;
            Debug.Log("ontrigger Exit car");
        }
    }

    public void setMove(bool c) { move = c; }

    public bool getMove() { return move; }
}