using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    private CarMovements[] allCarScripts;

    void Start()
    {
        allCarScripts = FindObjectsOfType<CarMovements>();
    }

    public void StartButtonClicked()
    {
        foreach (CarMovements car in allCarScripts)
        {
            car.TriggerCarStart();
        }
    }
}
