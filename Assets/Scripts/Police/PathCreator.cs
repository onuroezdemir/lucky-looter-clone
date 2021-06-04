using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathCreator : MonoBehaviour
{
    public enum StatePolice
    {
        wait= 0,
        walk = 1
    }

    public StatePolice currentState;

    public Transform police;

    public List<GameObject> pathObjects;

    public List<Vector3> paths;

    private bool isTurn = false;

    private int currentPath =0;

    [SerializeField] float speed = 2f;

    float timer = 3;
    private bool isStart = false;

    Animator animatorPolice;

    private void Awake()
    {
        animatorPolice = GetComponent<Animator>();

        for (int i = 0; i <pathObjects.Count; i++)
        {
            paths.Add(pathObjects[i].transform.position);
        }
    }

    private void Update()
    {
        MoveCheck();

        if (currentState == StatePolice.walk)
        {
            MovePolice();
        }

        CheckAnimation();
    }

    void MovePolice()
    {

        if (police.position != paths[currentPath])
        {
            Debug.Log(currentPath);
            Vector3 pos = Vector3.MoveTowards(transform.position, paths[currentPath], speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            police.LookAt(paths[currentPath]);
        }
        else
        {
            if (!isTurn)
            {
                currentPath = (currentPath + 1);
                if (currentPath == paths.Count - 1)
                {
                    isTurn = true;
                    isStart = true;
                }
            }
            else
            {
                currentPath = (currentPath - 1);
                if (currentPath == 0)
                {

                    isTurn = false;
                    isStart = true;
                }
            }

        }
    }

    void MoveCheck()
    {
        if (isStart)
        {
            if (currentPath-1 == (paths.Count ) || currentPath-1 == 0)
            {
                if (timer >= 0)
                {
                    currentState = StatePolice.wait;
                    timer -= Time.deltaTime;
                }
                else
                {
                    currentState = StatePolice.walk;
                    timer = 3f;
                    isStart = false;
                }

            }
        }  
    }

    void CheckAnimation()
    {
        switch (currentState)
        {
            case StatePolice.wait:
                animatorPolice.SetBool("isWalk", false);
                break;
            case StatePolice.walk:
                animatorPolice.SetBool("isWalk", true);
                break;
        }
    }




}
