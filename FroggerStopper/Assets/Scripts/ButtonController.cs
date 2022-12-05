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
    public bool soundOn;
    public Button soundButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;

    public GameObject controller;

    public GameObject losePanel;


    void Start()
    {
        controller = GameObject.Find("GameController");
        soundOn = true;
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
        SceneManager.LoadScene(2); // load main UIScene
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

    public void ChangeSoundSetting()
    {
        if (soundOn)
        {
            AudioListener.pause = true; // will have to test this once we have sound
            soundButton.GetComponent<Image>().sprite = soundOffIcon;
        }
        if (!soundOn)
        {
            AudioListener.pause = false;
            soundButton.GetComponent<Image>().sprite = soundOnIcon;
        }
        soundOn = !soundOn;
    }
}
