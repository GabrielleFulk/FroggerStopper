using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainGame : MonoBehaviour
{
    public GameObject square;
    public List<GameObject> Lane1 = new List<GameObject>();// these lists are to determine what lane each car is released from
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
    public List<Vector3> LanePos = new List<Vector3>();    // List of the positions to determine where the frogs are release FIXME
    public List<Vector3> LanePos1 = new List<Vector3>();  //positions for eachlane assign with the slots
    public List<Vector3> LanePos2 = new List<Vector3>();
    public List<Vector3> LanePos3 = new List<Vector3>();
    public List<Vector3> LanePos4 = new List<Vector3>();
    public List<Vector3> LanePos5 = new List<Vector3>();


    public Queue<string>[] FrogGroups; // List of all the frog collumns
    public List<string>[] FrogPos; //List of the positions to determine where the frogs are released

    public List<GameObject>[] Lanes; // List of all the lanes.
    public GameObject Frog1; //FixMe: these frogs are for the first iteration of the game and this should be done automaically in the future.
    public GameObject Frog2;
    public GameObject Frog3;
    public GameObject Frog4;
    public GameObject Frog5;
    public List<GameObject> AliveFrogs;



    public GameObject Car1; // FIXME
    public GameObject Car2;
    public GameObject Car3;

    public GameObject winPanel;
    public GameObject losePanel;

  





    // Start is called before the first frame update
    void Start()
    {
        AliveFrogs = new List<GameObject>() { Frog1, Frog2, Frog3,  Frog5 }; //FIXME
        FrogGroups = new Queue<string>[] { Frogs1, Frogs2, Frogs3, Frogs4, Frogs5, Frogs6 };
        Lanes = new List<GameObject>[] { Lane1, Lane2, Lane3, Lane4, Lane5, Lane6 };

        //Frogs1 = new Queue<string>() {"Frog","","Frog"};
        Lane1 = new List<GameObject>() { Car1, null, Car3 };
        LanePos = new List<Vector3>() { Car1.transform.position, Car2.transform.position, Car3.transform.position }; // do this for every lane SLOT FIXME
        Debug.Log(Lane1);
        Debug.Log(Lanes[1]);

    }

    public void RemoveFrog(GameObject theFrog){ //FIXME
        Debug.Log(theFrog.name);
        AliveFrogs.Remove(theFrog);
        Debug.Log(AliveFrogs.Count);
        if (AliveFrogs.Count == 0)
        {
            winPanel.SetActive(true);
        }
    }

    public void RunGame() //Willl call all the necisarry functions to run the game
    { 

    }
    public void StartCars()
    {
        LanePos = new List<Vector3>() { Car1.transform.position, Car2.transform.position, Car3.transform.position };
        StartCoroutine(Runcars(Lane1));
        
    }
    public IEnumerator Runcars(List<GameObject> Lane) //Willl call all the necisarry functions to run the game
    {
        while (Lane.Count() != 0)
        {
            if (Lane[0] != null)
            {
                CarMovements apple = Lane[0].GetComponent<CarMovements>();

                apple.TriggerCarStart();
            }

            Lane = Lane.Skip(1).ToList();
            yield return new WaitForSeconds(1.2f);
            for (int b = 0; b < Lane.Count(); b++)
            {
                if (Lane[b] != null)
                {
                    if (b == 0)
                    {
                        Lane[b].GetComponent<CarMovements>().awake = true;
                    }
                    Lane[b].transform.position = LanePos[b];
                    yield return new WaitForSeconds(.5f);
                }
            }
            yield return new WaitForSeconds(.5f);
        }
        yield return null;

                             //FIXME replace with all lanes not just lane 1
        //myObject.GetComponent<MyScript>().MyFunction(); FIXME
    }
    public void AddCar(GameObject car)
    {
        Lane1.Append(car);
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

    public void showLosePanel()
    {
        losePanel.SetActive(true);
    }

}


