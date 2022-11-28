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



    public bool awake;
    private SpriteRenderer sprite; 
    private bool snap; //whether or not a car is in a slot
    private Collider2D slot; // the slot the car snaps to
    private bool move; // whether or not the car is being moved by the mouse
    private bool go; // whether or not the car is moving down the road


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
        
        if (move) 
        {
            if (slot != null) slot.GetComponent<SlotScript>().setTaken(false);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z); 
        }


    }

    public void TriggerCarStart()
    {
        awake= true;
        rb.velocity = new Vector2(-carSpeed, 0);
        go = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "CarStopper")

        if (collider.gameObject.tag == "CarStopper" && go) 

        {
            Destroy(gameObject);
        }

        /*if (collider.gameObject.tag == "slot" && !collider.GetComponent<SlotScript>().getTaken())
        {
            snap = true;
            slot = collider;
            Debug.Log("ontrigger enter car");
            collider.GetComponent<SlotScript>().setTaken(true);
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot" && !collision.GetComponent<SlotScript>().getTaken())
        {
            snap = true;
            slot = collision;
            // Debug.Log("ontrigger enter car");
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot")
        {
            snap = false;
            slot = null;
            // Debug.Log("ontrigger Exit car");
            //collision.GetComponent<SlotScript>().setTaken(false);
        }
    }

    public void setMove(bool c) { move = c; }

    public bool getMove() { return move; }


    public bool getGo() { return go; }
    
    public bool getSnap() { return snap; }

    public Collider2D getSlot() { return slot; }
    
    public void delete()
    {
        Destroy(gameObject);
    }
}

