using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovements : MonoBehaviour
{
    public float carSpeed;
    private Rigidbody2D rb;
    private GameObject carStopper;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        carStopper = GameObject.Find("CarStopper");
    }

    void Update()
    {
        
    }

    public void TriggerCarStart()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CarStopper") 
        {
            Destroy(gameObject);
        }
    }
}
