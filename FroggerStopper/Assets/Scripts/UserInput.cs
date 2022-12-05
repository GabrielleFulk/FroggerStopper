using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject car;
    public Sprite purpleCar;
    public Sprite dumpTruck;
    public Sprite redCar;
    public GameObject controller;
    private bool busy; //mouse has a car
    private GameObject currentCar;
    private LayerMask layermask;

    void Start()
    {
        
        layermask = ~(LayerMask.GetMask("CarsLayer"));
        busy = false;
    }

    void Update()
    {
        
        /*if (hit && hit.collider.CompareTag("slot")) 
        {
            Debug.Log("drop");
            car.GetComponent<CarMovements>().setSnap(true); 

        }*/
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction,100f,layermask);
            /*if (hit && hit.collider.CompareTag("Car"))
            {
                CarMovements car = hit.collider.gameObject.GetComponent<CarMovements>();
                Debug.Log("hit");

                car.setMove(!car.getMove());
                if (car.getSnap() && !car.getMove() && !car.getGo())
                {
                    hit.collider.gameObject.transform.position = car.getSlot().transform.position;
                    car.getSlot().GetComponent<SlotScript>().setTaken(true);
                    Debug.Log("test");
                }
                if (!car.getSnap() && !car.getMove() && !car.getGo()) 
                {
                    Debug.Log("Destroy");
                    Destroy(hit.collider.gameObject);
                }
                
            }*/
            if (hit && hit.collider.CompareTag("slot") && currentCar != null && !hit.collider.GetComponent<SlotScript>().getTaken())
            {
                currentCar.transform.position = hit.collider.transform.position;
                currentCar.GetComponent<CarMovements>().setMove(false);
                hit.collider.GetComponent<SlotScript>().setCar(currentCar);
                controller.GetComponent<MainGame>().AddCar(hit.collider.gameObject,currentCar);
                currentCar = null;
                busy = false;
                hit.collider.GetComponent<SlotScript>().setTaken(true);
                
                

            }
            else if (hit && hit.collider.CompareTag("slot") && currentCar != null);
            //Moving car from slot
            else if (hit && hit.collider.CompareTag("slot") && currentCar == null && hit.collider.GetComponent<SlotScript>().getTaken())
            {
                UnityEngine.Debug.Log(hit.collider.GetComponent<SlotScript>().getCar());
                currentCar = hit.collider.GetComponent<SlotScript>().getCar();
                currentCar.GetComponent<CarMovements>().setMove(true);
                hit.collider.GetComponent<SlotScript>().setCar(null);
                hit.collider.GetComponent<SlotScript>().setTaken(false);
                busy = true;
                controller.GetComponent<MainGame>().RemoveCar(hit.collider.gameObject);
            }
            else if (busy && currentCar != null)
            {
                Destroy(currentCar);
                currentCar = null;
                busy = false;
                //DestroyImmediate(car, true); 
            }
        }
    }

    public void SpawnRedCar()
    {        
        if(!busy)
        {
            car.GetComponent<SpriteRenderer>().sprite = redCar;
            car.GetComponent<CarMovements>().points = 3;
            car.GetComponent<CarMovements>().carSpeed = 2;
            currentCar = Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
            busy = true;
        }
    }

    public void SpawnPurpleCar()
    {
        if (!busy)
        {
            car.GetComponent<SpriteRenderer>().sprite = purpleCar;
            car.GetComponent<CarMovements>().points = 4;
            car.GetComponent<CarMovements>().carSpeed = 4;
            currentCar = Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
            busy = true;
        }
    }

    public void SpawnDumpTruck()
    {
        if (!busy)
        {
            car.GetComponent<SpriteRenderer>().sprite = dumpTruck;
            car.GetComponent<CarMovements>().points = 5;
            car.GetComponent<CarMovements>().carSpeed = 1;
            currentCar = Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
            busy = true;
        }
    }
}
