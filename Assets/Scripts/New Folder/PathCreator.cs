using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathCreator : MonoBehaviour
{
    public Transform police;

    public List<GameObject> pathObjects;

    public List<Vector3> paths;


    private void Awake()
    {
        for (int i = 0; i <pathObjects.Count; i++)
        {
            paths.Add(pathObjects[i].transform.position);
        }
    }

    private void Start()
    {

        StartCoroutine(PoliceMovement());
       
        
    }

    IEnumerator PoliceMovement()
    {
        for (int i = 0; i < paths.Count; i++)
        {
            police.transform.LookAt(paths[i]);
            police.transform.DOLocalMove(paths[i], 2f, false);

        }
        yield return new WaitForSeconds(2f);
    }


}
