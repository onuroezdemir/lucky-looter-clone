using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && PlayerController.currentState != PlayerController.State.idle)
        {
            PoliceController.currentState = PoliceController.State.chase;

        }
    }
}
