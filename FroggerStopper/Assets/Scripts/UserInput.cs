using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
<<<<<<< HEAD
using Unity.VisualScripting;
=======
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
using UnityEngine;

public class UserInput : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< HEAD
    public GameObject car;
    void Start()
    {

=======
    bool move = true;
    public GameObject car;
    void Start()
    {
        
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0))
        {
=======

        if (Input.GetMouseButton(0))
        {
            move = true;
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.collider.CompareTag("Car"))
            {
<<<<<<< HEAD
                Debug.Log("hit");
                hit.collider.gameObject.GetComponent<CarBehavior>().setMove(!hit.collider.gameObject.GetComponent<CarBehavior>().getMove());
            }
        }
    }


=======
                //Debug.Log("hit");
                hit.collider.gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, hit.collider.gameObject.transform.position.z);
            }
        }
        else if (Input.GetMouseButtonUp(0)) { move = false; }
    }

    public void setMove(bool c) { move = c; }

    public bool getMove() {return move; }
>>>>>>> ec67dc14d9f908c77393c6b287afec27af6bcc59

    public void SpawnCar()
    {
        Instantiate(car, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
        Debug.Log("spawning car");
    }
}
