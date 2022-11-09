using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.collider.CompareTag("Car"))
            {
                Debug.Log("hit");
                hit.collider.gameObject.GetComponent<CarBehavior>().setMove(!hit.collider.gameObject.GetComponent<CarBehavior>().getMove());
            }
        }
    }



    public void SpawnCar()
    {
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
        Debug.Log("spawning car");
    }
}
