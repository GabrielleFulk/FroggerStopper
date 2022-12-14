using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainGame : MonoBehaviour
{
    public GameObject square;

    public List<GameObject> Lane1 = new List<GameObject>() { null,null,null};// these lists are to determine what lane each car is released from
    public List<GameObject> Lane2 = new List<GameObject>() { null, null, null };
    public List<GameObject> Lane3 = new List<GameObject>() { null, null, null };
    public List<GameObject> Lane4 = new List<GameObject>() { null, null, null };
    public List<GameObject> Lane5 = new List<GameObject>() { null, null, null };




    private List<string> DrivingCars = new List<string>(); // List of all the cars that are on the road. Mainly used for debuging

    private Queue<string> Frogs1 = new Queue<string>();// THes lists are to determine what collumn frogs are released from.
    private Queue<string> Frogs2 = new Queue<string>();
    private Queue<string> Frogs3 = new Queue<string>();
    private Queue<string> Frogs4 = new Queue<string>();
    private Queue<string> Frogs5 = new Queue<string>();
    private Queue<string> Frogs6 = new Queue<string>();
       // List of the positions to determine where the frogs are release FIXME
   // public List<Vector3> LanePos1 = new List<Vector3>();  //positions for eachlane assign with the slots
   // public List<Vector3> LanePos2 = new List<Vector3>();
   // public List<Vector3> LanePos3 = new List<Vector3>();
   // public List<Vector3> LanePos4 = new List<Vector3>();
    //public List<Vector3> LanePos5 = new List<Vector3>();
    public List<Vector3>[] LanePos;


    public Queue<string>[] FrogGroups; // List of all the frog collumns
    public List<string>[] FrogPos; //List of the positions to determine where the frogs are released

    public List<GameObject>[] Lanes; // List of all the lanes.
    public GameObject Frog1; //FixMe: these frogs are for the first iteration of the game and this should be done automaically in the future.
    public GameObject Frog2;
    public GameObject Frog3;
    public GameObject Frog4;
    public GameObject Frog5;
    public List<GameObject> AliveFrogs;



    public UnityEngine.UI.Button Car1Button;
    public UnityEngine.UI.Button Car2Button;
    public UnityEngine.UI.Button Car3Button;

    public int car1Points;
    public int car2Points;
    public int car3Points;

    public GameObject oneStarWinPanel;
    public GameObject twoStarWinPanel;
    public GameObject threeStarWinPanel;
    public GameObject losePanel;
    

    public TMP_Text panel1PointsText;
    public TMP_Text panel2PointsText;
    public TMP_Text panel3PointsText;

    public int totalPoints;
    public TMP_Text pointsText;

    int threeStarWin;
    int twoStarWin;

    public AudioSource backgroundMusic;
    public GameObject winSound;
    public GameObject loseSound;

    public string currentLevel;
    bool gameStarted;

    public string level;


    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
         //set starting points based on the level
        if (currentLevel == "Level1")
        {
            totalPoints = 15;
            threeStarWin = 5;
            twoStarWin = 3;
        }
        else if (currentLevel == "level2")
        {
            totalPoints = 20;
            threeStarWin = 6;
            twoStarWin = 4;
        }
        else if (currentLevel == "Level3")
        {
            totalPoints = 20;
            threeStarWin = 5;
            twoStarWin = 3;
        }
        else if (currentLevel == "Level4")
        {
            totalPoints = 36;
            threeStarWin = 12;
            twoStarWin = 6;
        }
        else //just in case a level isn't able to be detected for some reason
        {
            totalPoints = 15;
            threeStarWin = 5;
            twoStarWin = 3;
        }

        pointsText.text = ("Points: " + totalPoints);
        car1Points = 5;
        car2Points = 4;
        car3Points = 6;
        

        gameStarted = false;

        AliveFrogs = new List<GameObject>(); //FIXME

        foreach(GameObject alivefrog in GameObject.FindGameObjectsWithTag("Frog"))
        {
            AliveFrogs.Add(alivefrog);
        }
        FrogGroups = new Queue<string>[] { Frogs1, Frogs2, Frogs3, Frogs4, Frogs5, Frogs6 };

        Lane1 = new List<GameObject>() { null, null, null };// these lists are to determine what lane each car is released from
        Lane2 = new List<GameObject>() { null, null, null };
        Lane3 = new List<GameObject>() { null, null, null };
        Lane4 = new List<GameObject>() { null, null, null };
        Lane5 = new List<GameObject>() { null, null, null };

        Lanes = new List<GameObject>[] { Lane1, Lane2, Lane3, Lane4, Lane5};
        LanePos = new List<Vector3>[] { null,null,null,null,null};
        //Frogs1 = new Queue<string>() {"Frog","","Frog"};
      
       
        //LanePos = new List<Vector3>() { Car1.transform.position, Car2.transform.position, Car3.transform.position }; // do this for every lane SLOT FIXME
      
        for(int a = 1; a <= 5; a++)
        {
           
            Vector3 fill =new Vector3(0f, 0f, 0f);
            List<Vector3> lane = new List<Vector3>();
            for (int b = 0; b <= 2; b++)
            {
                string m = a.ToString();
                string n = b.ToString();
                //Debug.Log("Lane_" + m + "_" + n);
                GameObject temp = GameObject.Find("Lane_" + m + "_" + n);
                Debug.Log(temp.transform.position);
                lane.Add(temp.transform.position);
                Debug.Log(lane[b]);

            }
            LanePos[a-1] = lane;
        }
        

    }
    public void AddCar(GameObject slot, GameObject car)
    {

        //Debug.Log(slot.name);
        string[] helpers = (slot.name).Split("_");

        int lanenum = int.Parse(helpers[1]);

        int subnum = int.Parse(helpers[2]);
        //Debug.Log((lanenum,subnum));
        Lanes[lanenum-1][subnum] = car;
        Debug.Log(Lanes[lanenum-1][subnum].name);

        // Deduct available points based on which car is placed
        totalPoints -= car.GetComponent<CarMovements>().points;
        pointsText.text = ("Points: " + totalPoints);
    }

    public void RemoveCar(GameObject slot)
    {
        string[] helpers = (slot.name).Split("_");

        int lanenum = int.Parse(helpers[1]);

        int subnum = int.Parse(helpers[2]);

        // Add back points when a car is taken out of the line up
        totalPoints += Lanes[lanenum - 1][subnum].GetComponent<CarMovements>().points;
        pointsText.text = ("Points: " + totalPoints);

        Lanes[lanenum - 1][subnum] = null;
    }

    public void RemoveFrog(GameObject theFrog){ //FIXME
        Debug.Log(theFrog.name);
        AliveFrogs.Remove(theFrog);
        Debug.Log(AliveFrogs.Count);
        if (AliveFrogs.Count == 0)
        {
            backgroundMusic.Stop();
            winSound.SetActive(true);
            if (totalPoints >= threeStarWin)
            {
                panel3PointsText.text = ("Points leftover: " + totalPoints);
                PlayerPrefs.SetInt("level"+level+"Stars", 3);
                threeStarWinPanel.SetActive(true);
            } else if (totalPoints >= twoStarWin)
            {
                panel2PointsText.text = ("Points leftover: " + totalPoints);
                twoStarWinPanel.SetActive(true);
                if (PlayerPrefs.GetInt("level"+level+"Stars") <2) PlayerPrefs.SetInt("level"+level+"Stars", 2);
            } else
            {
                panel1PointsText.text = ("Points leftover: " + totalPoints);
                oneStarWinPanel.SetActive(true);
                if (PlayerPrefs.GetInt("level"+level+"Stars") < 1) PlayerPrefs.SetInt("level"+level+"Stars", 1);
            }
        }
    }

    public void RunGame() //Will call all the necisarry functions to run the game
    { 

    }

    public void StartCars()
    {
        gameStarted = true;
        StartCoroutine(Runcars(Lane1,1));
        StartCoroutine(Runcars(Lane2, 2));
        StartCoroutine(Runcars(Lane3, 3));
        StartCoroutine(Runcars(Lane4, 4));
        StartCoroutine(Runcars(Lane5, 5));


    }

    public IEnumerator Runcars(List<GameObject> Lane,int i) //Will call all the necisarry functions to run the game
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
                    Lane[b].transform.position = LanePos[i-1][b];   // FIXME RIGHT NOW THERE IS AN ISSUE WITH THIS
                    yield return new WaitForSeconds(2f);
                }
            }
            yield return new WaitForSeconds(.5f);
        }
        yield return null;

        //FIXME replace with all lanes not just lane 1
        //myObject.GetComponent<MyScript>().MyFunction(); FIXME
    }

    void Update()
    {
        // Check if each car can be purchased
        if (!gameStarted)
        {
            if (totalPoints < car1Points) Car1Button.interactable = false;
            if (totalPoints >= car1Points) Car1Button.interactable = true;
            if (totalPoints < car2Points) Car2Button.interactable = false;
            if (totalPoints >= car2Points) Car2Button.interactable = true;
            if (totalPoints < car3Points) Car3Button.interactable = false;
            if (totalPoints >= car3Points) Car3Button.interactable = true;
        }        
    }

    public void showLosePanel()
    {   
        backgroundMusic.Stop();
        losePanel.SetActive(true);
        loseSound.SetActive(true);
    }

}


