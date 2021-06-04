using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public enum State
    {
        idle = 0,
        run = 1
    }

    public static State currentState;

    public GameObject human;
    public GameObject box;

    private Rigidbody body;
    private Animator animator;

    [Space]
    [SerializeField] private float speed = 1f;

    private Vector3 startMousePos = Vector3.zero;
    private Vector3 deltaMousePos = Vector3.zero;
    private Vector3 direction = Vector3.zero;
   

    private void Awake()
    {
        currentState = State.idle;
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        InputController();
        ViewController();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaMousePos = Input.mousePosition - startMousePos;
            direction = new Vector3(deltaMousePos.x, 0f, deltaMousePos.y);

            body.velocity = direction.normalized * speed;
            body.rotation = Quaternion.LookRotation(body.velocity);
        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }

    void ViewController()
    {
        switch (currentState)
        {
            case State.idle:
                human.SetActive(false);
                // TO DO: Dotween scale down
                box.SetActive(true);
                break;
            case State.run:
                box.SetActive(false);
                animator.SetTrigger("isRun");
                // TO DO: Dotween scale down
                human.SetActive(true);
                break;
        }
    }

    void InputController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentState = State.run;
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentState = State.idle;
        }
    }


}
