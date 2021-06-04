using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceAgentAI : MonoBehaviour
{
    Transform player;
    NavMeshAgent policeAgent;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        policeAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(player != null)
        {
            policeAgent.SetDestination(player.position);
            transform.LookAt(player.transform);
        }
        
    }

}
