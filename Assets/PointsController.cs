using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private GameObject currentBox;

    public GameObject finishButton;
    public Material finishedMaterial;

    void Start()
    {
        currentBox = gameObject;
    }
    // Start is called before the first frame update
    public void FinishManipulation()
    {
        if (currentBox != null)
        {
            foreach (Transform child in currentBox.transform)
            {
                if (child.name == "PointA" || child.name == "PointB")
                {
                    child.gameObject.SetActive(false);
                }
                else if(child.name == "Cube")
                {
                    Renderer renderer = child.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = finishedMaterial;
                    }
                }
            }
        }

        finishButton.gameObject.SetActive(false);
    }
}
