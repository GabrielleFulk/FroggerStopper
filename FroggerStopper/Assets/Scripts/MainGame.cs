using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public GameObject square;
    private List<GameObject> Lane1 = new List<GameObject>();// these lists are to determine what lane each car is released from
    private List<GameObject> Lane2 = new List<GameObject>();
    private List<GameObject> Lane3 = new List<GameObject>();
    private List<GameObject> Lane4 = new List<GameObject>();
    private List<GameObject> Lane5 = new List<GameObject>();
    private List<GameObject> Lane6 = new List<GameObject>();

    private List<string> DrivingCars = new List<string>(); // List of all the cars that are on the road. Mainly used for debuging

    private Queue<string> Frogs1 = new Queue<string>();// THes lists are to determine what collumn frogs are released from.
    private Queue<string> Frogs2 = new Queue<string>();
    private Queue<string> Frogs3 = new Queue<string>();
    private Queue<string> Frogs4 = new Queue<string>();
    private Queue<string> Frogs5 = new Queue<string>();
    private Queue<string> Frogs6 = new Queue<string>();
    public Queue<string>[] FrogGroups; // List of all the frog collumns
    public List<string>[] FrogPos; //List of the positions to determine where the frogs are released
    public List<string>[] LanePos; // Lis of the positions to determine where the frogs are release
    public List<GameObject>[] Lanes; // List of all the lanes.
    public GameObject Frog1; //FixMe: these frogs are for the first iteration of the game and this should be done automaically in the future.
    public GameObject Frog2;
    public GameObject Frog3;
    public GameObject Frog4;
    public GameObject Frog5;
    public List<GameObject> AliveFrogs;
  





    // Start is called before the first frame update
    void Start()
    {

        AliveFrogs = new List<GameObject>() { Frog1, Frog2, Frog3,  Frog5 }; //FIXME
        FrogGroups = new Queue<string>[] { Frogs1, Frogs2, Frogs3, Frogs4, Frogs5, Frogs6 };
        Lanes = new List<GameObject>[] { Lane1, Lane2, Lane3, Lane4, Lane5, Lane6 };
        //Frogs1 = new Queue<string>() {"Frog","","Frog"};
        //Lane1 = new Queue<string>() {"Standard","SUV","RaceCar"};
        Debug.Log(Lane1);
        Debug.Log(Lanes[1]);

    }
    public void RemoveFrog(GameObject theFrog){ //FIXME
        Debug.Log(theFrog.name);
        AliveFrogs.Remove(theFrog);
        if (AliveFrogs.Count == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        }
    //TODO WRITE CODE TO KEEP TRACK IF ITS IN THE QUEUE OR NOT
    public void RunGame() //Willl call all the necisarry functions to run the game
    {
        
        //myObject.GetComponent<MyScript>().MyFunction(); FIXME
    }
    public void AddCar(GameObject car)
    {
        Lane1.Append(car);

    }
    public void RemoveCar(GameObject car)
    {
        Lane1.Remove(car);
    }
    IEnumerator ReleaseFromArray(List<GameObject> arr)
    {
        Debug.Log("Go");
        if (arr.Count > 0)
        {
            Debug.Log(arr.Count);
            GameObject apple = arr[0];
            arr.RemoveAt(0);
            Destroy(apple);
            Debug.Log(arr.Count);
            yield return new WaitForSeconds(10f);
        }
        else
        {
            yield return null;
        }
    }

    // Update is called once per frame

    void Update()
    {
      
    }



}


