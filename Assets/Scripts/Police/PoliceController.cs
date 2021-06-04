using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceController : MonoBehaviour
{
   public enum State
    {
        guard = 0,
        chase = 1
    }

    public static State currentState;

    private PoliceAgentAI agentComponent;
    private PathCreator guardComponent;
    private NavMeshAgent navMeshPolice;
    
    public GameObject light;
    private Animator policeAnimator;

    private void Awake()
    {
        agentComponent = GetComponent<PoliceAgentAI>();
        guardComponent = GetComponent<PathCreator>();
        navMeshPolice = GetComponent<NavMeshAgent>();
        policeAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.guard:
                agentComponent.enabled = false;
                navMeshPolice.enabled = false;
                guardComponent.enabled = true;
                break;
            case State.chase:
                agentComponent.enabled = true;
                navMeshPolice.enabled = true;
                guardComponent.enabled = false;
                light.GetComponent<Light>().color = Color.red;
                policeAnimator.SetTrigger("isRun");
                break;
        }

    }

}
