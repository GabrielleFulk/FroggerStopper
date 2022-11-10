using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovements : MonoBehaviour
{
    public float carSpeed;
    private Rigidbody2D rb;
    private GameObject carStopper;
    private UserInput userInput;
    private bool snap;
    private Collider2D slot;
    public int points;
    public Sprite carImage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        carStopper = GameObject.Find("CarStopper");
        userInput = FindObjectOfType<UserInput>();
        snap = false;
    }

    void Update()
    {
        if(snap && !Input.GetMouseButton(0))
        {
            transform.position = slot.transform.position;
            snap = false;
        }
    }

    public void TriggerCarStart()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
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
        }
    }
}
