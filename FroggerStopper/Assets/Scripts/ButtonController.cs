using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private CarMovements[] allCarScripts;
    private FrogMovement[] allFrogScripts;
    public Button PlayButton;
    public Button Car1Button;
    public Button Car2Button;
    public Button Car3Button;

    public GameObject controller;

    public GameObject losePanel;


    void Start()
    {
       
        Debug.Log("hit");
        controller = GameObject.Find("GameController");
    }

    public void StartButtonClicked()
    {
        PlayButton.interactable = false;
        // Car1Button.interactable = false;
        // Car2Button.interactable = false;
        // Car3Button.interactable = false;
        controller.GetComponent<MainGame>().StartCars();
        allCarScripts = FindObjectsOfType<CarMovements>(); //Fixme and do a loop for every lane
        
        allFrogScripts = FindObjectsOfType<FrogMovement>();
        foreach (CarMovements car in allCarScripts)
        {
            //car.TriggerCarStart();
        }
        foreach(FrogMovement frog in allFrogScripts)
        {
            frog.TriggerFrogStart();
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("LevelsScene"); // load LevelsScen
    }

    public void LevelOneButtonClicked() // load main UIScene
    {
        SceneManager.LoadScene(2);
    }

    public void HowButtonClicked()
    {
        SceneManager.LoadScene(1); // load instructions scene
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene(0); // load title scene
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void resetStars()
    {
        PlayerPrefs.SetInt("levelOneStars", 0);
    }
}
