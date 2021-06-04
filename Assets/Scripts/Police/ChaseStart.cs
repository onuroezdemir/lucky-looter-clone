using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PoliceController.currentState = PoliceController.State.chase;

        }
    }
}
