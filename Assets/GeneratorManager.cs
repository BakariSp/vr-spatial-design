using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public GameObject boxGenerator;
    private static GameObject _centerEyeAnchor;
    public Vector3 offset; // Distance from the camera
    private GameObject InstantiatedBox;

    void Awake()
    {
        // If the static reference is null, find the CenterEyeAnchor
        if (_centerEyeAnchor == null)
        {
            _centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
            if (_centerEyeAnchor == null)
            {
                Debug.LogError("CenterEyeAnchor not found.");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InstantiateBoxGenerator();
    }

    // create a new instance of the box generator
    public void InstantiateBoxGenerator()
    {
        Vector3 newPosition = _centerEyeAnchor.transform.position +
                              _centerEyeAnchor.transform.right * offset.x +
                              _centerEyeAnchor.transform.up * offset.y +
                              _centerEyeAnchor.transform.forward * offset.z;

        // Calculate the direction to look at (y-axis only)
        Vector3 direction = newPosition - _centerEyeAnchor.transform.position;
        direction.y = 0; // Only care about y-axis rotation

        InstantiatedBox = Instantiate(boxGenerator);
        InstantiatedBox.transform.position = newPosition;
        InstantiatedBox.transform.rotation = Quaternion.LookRotation(direction);
    }
    
}
