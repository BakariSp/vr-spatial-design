using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private GameObject currentBox;
    public GameObject finishButton;
    public Material finishedMaterial;
    private GameObject InstanceBox;
    [SerializeField] private bool isFinished = false;

    void Start()
    {
        currentBox = gameObject;
    }

    public void StartManipulation()
    {
        if (currentBox == null)
            return;

        foreach(Transform child in currentBox.transform) 
        {
            child.gameObject.SetActive(true);
            finishButton.gameObject.SetActive(true);
            isFinished = false;
        }
    }

    // Start is called before the first frame update
    public void FinishManipulation()
    {
        if (currentBox != null)
        {
            if (!isFinished) {
                foreach (Transform child in currentBox.transform)
                {
                    if (child.name == "PointA" || child.name == "PointB")
                    {
                        child.gameObject.SetActive(false);
                        isFinished = true;
                    }
                    //else if(child.name == "Cube")
                    //{
                    //    InstanceBox = Instantiate(child.gameObject, child.transform.position, child.transform.rotation);
                    //    Renderer renderer = InstanceBox.GetComponent<Renderer>();
                    //    if (renderer != null)
                    //    {
                    //        renderer.material = finishedMaterial;
                    //    }
                    //}
                }
            }
            else 
            {
                foreach (Transform child in currentBox.transform)
                {
                    if (child.name == "PointA" || child.name == "PointB")
                    {
                        child.gameObject.SetActive(true);
                        isFinished = false;
                    }
                }
            }
        }

        finishButton.gameObject.SetActive(false);
    }
}
