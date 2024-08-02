using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject box;

    // [SerializeField] private Vector3 boxCenter;
    void Update()
    {
        UpdateBox();
    }

    void UpdateBox()
    {
        // Calculate the new center and scale of the box
        Vector3 newBoxCenter = (pointA.position + pointB.position) / 2;
        Vector3 newBoxScale = new Vector3(Mathf.Abs(pointA.position.x - pointB.position.x),
                                          Mathf.Abs(pointA.position.y - pointB.position.y),
                                          Mathf.Abs(pointA.position.z - pointB.position.z));

        // Update the box position and scale
        box.transform.position = newBoxCenter;
        box.transform.localScale = newBoxScale;
    }
}
