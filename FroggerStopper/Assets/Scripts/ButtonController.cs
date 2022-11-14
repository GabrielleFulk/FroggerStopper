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
    public Button CarButton;

    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
    }

    public void StartButtonClicked()
    {
        PlayButton.interactable = false;
        CarButton.interactable = false;
        allCarScripts = FindObjectsOfType<CarMovements>();
        allFrogScripts = FindObjectsOfType<FrogMovement>();
        foreach (CarMovements car in allCarScripts)
        {
            car.TriggerCarStart();
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

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }
}
