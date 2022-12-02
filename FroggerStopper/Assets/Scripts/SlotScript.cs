using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool taken;
    GameObject car;
    void Start()
    {
        taken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTaken(bool t)
    {
        taken = t;
    }

    public bool getTaken() { return taken; }

    public void setCar(GameObject c) { car = c; }

    public GameObject getCar() { return car; }  
}
