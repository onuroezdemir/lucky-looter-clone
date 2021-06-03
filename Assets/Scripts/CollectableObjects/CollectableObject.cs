using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour, ICollectable
{

    [Space]
    [SerializeField] private Vector3 yAddOn = new Vector3(0f,4f,0f);
    [Space]
    [SerializeField] private int costValue = 1;
    public int cost => costValue;

    public Material goldMaterial;


    public GameObject costText;

    private void Start()
    {
        if (costValue > 5)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = goldMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ScaleDownAndDestroy(other.gameObject)); 
        }
    }

    IEnumerator ScaleDownAndDestroy(GameObject collider)
    {
        GameObject costTextObject = Instantiate(costText, this.gameObject.transform.position,new Quaternion(0f,0f,0f,0f));
        costTextObject.GetComponent<TextMesh>().text = "+" + cost.ToString();
        costTextObject.transform.DOMove(costTextObject.transform.position+yAddOn, 1, false);
        costTextObject.transform.DOScale(Vector3.zero, 2f);

        this.gameObject.transform.DOBlendablePunchRotation(collider.transform.rotation.eulerAngles, 1f,1,1f);
        this.gameObject.transform.DOMove(collider.transform.position + yAddOn, 0.25f, false);
        this.gameObject.transform.DOMove(collider.transform.position , 0.25f, false);

        this.gameObject.transform.DOScale(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(costTextObject);
        Destroy(this.gameObject);

    }
}
