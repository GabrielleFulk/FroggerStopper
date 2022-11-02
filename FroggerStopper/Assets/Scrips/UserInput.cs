using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    // Start is called before the first frame update
    bool move = true;
    public GameObject car;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            move = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.collider.CompareTag("Car"))
            {
                //Debug.Log("hit");
                hit.collider.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, hit.collider.gameObject.transform.position.z);
            }
        }
        else if (Input.GetMouseButtonUp(0)){ move = false; }
    }

    public void setMove(bool c) { move = c; }

    public bool getMove() {return move; }

    public void SpawnCar()
    {
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
    }
}
