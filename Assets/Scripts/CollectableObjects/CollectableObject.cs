using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectableObject : MonoBehaviour, ICollectable
{

    [Space]
    [SerializeField] private Vector3 yAddOn = new Vector3(0f,4f,0f);
    [Space]
    [SerializeField] private int costValue = 1;
    public int cost => costValue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ScaleDownAndDestroy(other.gameObject)); 
        }
    }

    IEnumerator ScaleDownAndDestroy(GameObject collider)
    {

        this.gameObject.transform.DOMove(collider.transform.position + yAddOn, 0.25f, false);
        this.gameObject.transform.DOMove(collider.transform.position , 0.25f, false);

        this.gameObject.transform.DOScale(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);

    }
}
