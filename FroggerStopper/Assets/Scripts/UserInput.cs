using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.collider.CompareTag("Car"))
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
                
            }
        }
    }

    public void SpawnRedCar()
    {        
        car.GetComponent<SpriteRenderer>().sprite = redCar;
        car.GetComponent<CarMovements>().points = 5;
        car.GetComponent<CarMovements>().carSpeed = 2;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }

    public void SpawnPurpleCar()
    {
        car.GetComponent<SpriteRenderer>().sprite = purpleCar;
        car.GetComponent<CarMovements>().points = 4;
        car.GetComponent<CarMovements>().carSpeed = 4;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }

    public void SpawnDumpTruck()
    {
        car.GetComponent<SpriteRenderer>().sprite = dumpTruck;
        car.GetComponent<CarMovements>().points = 6;
        car.GetComponent<CarMovements>().carSpeed = 1;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }
}
