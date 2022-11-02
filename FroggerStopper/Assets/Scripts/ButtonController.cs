using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private CarMovements[] allCarScripts;

    void Start()
    {
    }

    public void StartButtonClicked()
    {
        allCarScripts = FindObjectsOfType<CarMovements>();
        foreach (CarMovements car in allCarScripts)
        {
            car.TriggerCarStart();
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
}
