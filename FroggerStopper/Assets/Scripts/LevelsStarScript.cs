using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsStarScript : MonoBehaviour
{
    int[] levelStars;
    public GameObject lvlOneNoStars;
    public GameObject lvlOneOneStars;
    public GameObject lvlOneTwoStars;
    public GameObject lvlOneThreeStars;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("levelOneStars") == 0)
        {
            lvlOneNoStars.SetActive(true);
        }
        if (PlayerPrefs.GetInt("levelOneStars") == 1)
        {
            lvlOneNoStars.SetActive(false);
            lvlOneOneStars.SetActive(true);
        }
        if (PlayerPrefs.GetInt("levelOneStars") == 2)
        {
            lvlOneNoStars.SetActive(false);
            lvlOneOneStars.SetActive(false);
            lvlOneTwoStars.SetActive(true);
        }
        if (PlayerPrefs.GetInt("levelOneStars") == 3)
        {
            lvlOneNoStars.SetActive(false);
            lvlOneOneStars.SetActive(false);
            lvlOneTwoStars.SetActive(false);
            lvlOneThreeStars.SetActive(true);
        }
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
            Debug.Log("star");
            lvlOneOneStars.SetActive(true);
        }
    }
}
