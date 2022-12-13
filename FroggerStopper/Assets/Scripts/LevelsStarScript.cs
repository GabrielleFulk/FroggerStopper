using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsStarScript : MonoBehaviour
{
    string[] starValues = { "levelOneStars", "levelTwoStars", "levelThreeStars", "LevelFourStars" };
    public GameObject[] levelStars;
    public GameObject lvlOneNoStars;
    public GameObject lvlOneOneStars;
    public GameObject lvlOneTwoStars;
    public GameObject lvlOneThreeStars;
    // Start is called before the first frame update
    void Start()
    {
        int m = 0;
        for (int i = 0; i < 2; i++) 
        {
            GameObject noStars, oneStars, twoStars, threeStars;
            noStars  = levelStars[m];
            oneStars = levelStars[m+1];
            twoStars = levelStars[m+2];
            threeStars = levelStars[m+3];
            if (PlayerPrefs.GetInt(starValues[i]) == 0)
            {
                noStars.SetActive(true);
            }
            if (PlayerPrefs.GetInt(starValues[i]) == 1)
            {
                noStars.SetActive(false);
                oneStars.SetActive(true);
            }
            if (PlayerPrefs.GetInt(starValues[i]) == 2)
            {
                noStars.SetActive(false);
                oneStars.SetActive(false);
                twoStars.SetActive(true);
            }
            if (PlayerPrefs.GetInt(starValues[i]) == 3)
            {
                noStars.SetActive(false);
                oneStars.SetActive(false);
                twoStars.SetActive(false);
                threeStars.SetActive(true);
                Debug.Log("3");
            }
            m += 4;
        }/**/
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("levelOneStars") == 0)
        {
            lvlOneNoStars.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("levelOneStars") == 1)
        {
            // Debug.Log("star");
            lvlOneOneStars.SetActive(true);
        }
    }
}
