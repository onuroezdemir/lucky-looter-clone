using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
            EventManager.OnGoalAchieved?.Invoke();
        }
    }
}
