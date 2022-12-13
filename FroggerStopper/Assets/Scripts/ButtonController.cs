using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private CarMovements[] allCarScripts;
    private FrogMovement[] allFrogScripts;
    private FastFrogMovement[] allFastFrogScripts;
    public Button PlayButton;
    public Button Car1Button;
    public Button Car2Button;
    public Button Car3Button;
    public Button showFrogButton;
    public GameObject Camera;
    public bool soundOn;
    public Button soundButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;

    public GameObject controller;

    public GameObject losePanel;


    void Start()
    {
        controller = GameObject.Find("GameController");
        Camera = GameObject.Find("Main Camera");
        soundOn = true;

    }

    public void StartButtonClicked()
    {
        PlayButton.interactable = false;       
        showFrogButton.interactable = false;
        Car1Button.interactable = false;
        Car2Button.interactable = false;
        Car3Button.interactable = false;
        controller.GetComponent<MainGame>().StartCars();        
        allFrogScripts = FindObjectsOfType<FrogMovement>();
        allFastFrogScripts = FindObjectsOfType<FastFrogMovement>();
        foreach(FrogMovement frog in allFrogScripts)
        {
            frog.TriggerFrogStart();
        }
        foreach(FastFrogMovement frog in allFastFrogScripts)
        {
            frog.TriggerFrogStart();
        }
    }
    public void ShowFrogs()
    {
        StartCoroutine(lerp());   
    }
    IEnumerator lerp()
    {
        float endValue = -6;
        float startValue = 0;
        if (Camera.transform.position.y < -0.5)
        {
            endValue = 0;
            startValue = -6;
        }
        float lerpDuration = 1.5f;
        float timeElapsed = 0;

        float valueToLerp;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            Camera.transform.position = new Vector3(0, valueToLerp, -10);
            showFrogButton.interactable = false;

            yield return null;
        }
        showFrogButton.interactable = true;

        valueToLerp = endValue;
    }
  

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("LevelsScene"); // load LevelsScen
    }

    public void LevelOneButtonClicked() 
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelTwoButtonClicked()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelThreeButtonClicked()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LevelFourButtonClicked()
    {
        SceneManager.LoadScene("Level4");
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(controller.GetComponent<MainGame>().currentLevel);
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
