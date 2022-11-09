using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
=======
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
<<<<<<< HEAD
    private bool snap;
    private Collider2D slot;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
=======
    private UserInput userInput;
    private bool snap;
    private Collider2D slot;
    // Start is called before the first frame update
    void Start()
    {
        userInput = FindObjectOfType<UserInput>();
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
        snap = false;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (snap && !move)
        {
            transform.position = slot.transform.position;

        }
        if (!move & !snap) Destroy(gameObject);
        if (move) transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collide");
=======
       
        
        if(snap && !Input.GetMouseButton(0))
        {
            transform.position = slot.transform.position;
            snap = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
        if (collider.gameObject.tag == "slot")
        {
            snap = true;
            slot = collider;
<<<<<<< HEAD
            Debug.Log("Collide 2");
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot")
        {
            snap = false;
            slot = null;
        }
    }

    public void setMove(bool c) { move = c; }

    public bool getMove() { return move; }
}
=======
        }
    }
}
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
