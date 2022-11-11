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
                Debug.Log("hit");
                hit.collider.gameObject.GetComponent<CarMovements>().setMove(!hit.collider.gameObject.GetComponent<CarMovements>().getMove());
            }
        }
    }

    public void SpawnRedCar()
    {        
        car.GetComponent<SpriteRenderer>().sprite = redCar;
        car.GetComponent<CarMovements>().points = 3;
        car.GetComponent<CarMovements>().carSpeed = 2;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }

    public void SpawnPurpleCar()
    {
        car.GetComponent<SpriteRenderer>().sprite = purpleCar;
        car.GetComponent<CarMovements>().points = 7;
        car.GetComponent<CarMovements>().carSpeed = 4;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }

    public void SpawnDumpTruck()
    {
        car.GetComponent<SpriteRenderer>().sprite = dumpTruck;
        car.GetComponent<CarMovements>().points = 5;
        car.GetComponent<CarMovements>().carSpeed = 1;
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }
}
