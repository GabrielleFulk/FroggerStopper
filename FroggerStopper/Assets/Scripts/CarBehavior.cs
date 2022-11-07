using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private UserInput userInput;
    private bool snap;
    private Collider2D slot;
    // Start is called before the first frame update
    void Start()
    {
        userInput = FindObjectOfType<UserInput>();
        snap = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(snap && !Input.GetMouseButton(0))
        {
            transform.position = slot.transform.position;
            snap = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "slot")
        {
            snap = true;
            slot = collider;
        }
    }
}
