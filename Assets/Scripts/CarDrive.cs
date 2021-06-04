using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarDrive : MonoBehaviour
{

    public GameObject playerInCar;



    private void OnEnable()
    {
        EventManager.OnGoalAchieved.AddListener(AddForceCar);
    }

    private void OnDisable()
    {
        EventManager.OnGoalAchieved.RemoveListener(AddForceCar);
    }

    public void AddForceCar()
    {
        playerInCar.SetActive(true);
        this.gameObject.transform.DOMoveX(20, 10);
    }
}
