using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

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
    private Queue<string> Frogs4 = new Queue< string >();
    private Queue<string> Frogs5 = new Queue<string>();
    private Queue<string> Frogs6 = new Queue<string>();
    public Queue<string>[] FrogGroups; // List of all the frog collumns
    public List<string>[] FrogPos; //List of the positions to determine where the frogs are released
    public List<string>[] LanePos; // Lis of the positions to determine where the frogs are release
    public List<GameObject>[] Lanes; // List of all the lanes.


    // Start is called before the first frame update
    void Start()
    {
        FrogGroups = new Queue<string>[] { Frogs1, Frogs2, Frogs3, Frogs4, Frogs5, Frogs6 };
        Lanes = new List<GameObject>[] { Lane1, Lane2, Lane3, Lane4, Lane5, Lane6 };
        //Frogs1 = new Queue<string>() {"Frog","","Frog"};
        //Lane1 = new Queue<string>() {"Standard","SUV","RaceCar"};
        Debug.Log(Lane1);
        Debug.Log(Lanes[1]);
        
    }
    public void RunGame() //Willl call all the necisarry functions to run the game
    {
        Lane1.Add(square);
        List<GameObject> arr = Lane1;
        StartCoroutine(ReleaseFromArray(arr)); 
    }
    IEnumerator ReleaseFromArray( List<GameObject> arr)
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
        else {
            yield return null;
        }
    }

    // Update is called once per frame
    
    void Update()
    {
      
    }
    


}
