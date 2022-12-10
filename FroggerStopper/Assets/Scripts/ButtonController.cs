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
    public Button showFrogButton;
    public GameObject Camera;

    public GameObject controller;

    public GameObject losePanel;


    void Start()
    {
        controller = GameObject.Find("GameController");
        Camera = GameObject.Find("Main Camera");
    }

    public void StartButtonClicked()
    {
        PlayButton.interactable = false;
        // Car1Button.interactable = false;
        // Car2Button.interactable = false;
        // Car3Button.interactable = false;
        showFrogButton.interactable = false;
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
}
