using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private bool snap;
    private Collider2D slot;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
        snap = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (collider.gameObject.tag == "slot")
        {
            snap = true;
            slot = collider;
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