using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    public GameObject panel; // Assign the UI Panel here
    [SerializeField] private bool _startState = false;
    private static GameObject _centerEyeAnchor;
    public Vector3 offset; // Distance from the camera

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

    void Start()
    {
        panel.SetActive(_startState); // Ensure the panel is initially inactive
    }

    public void ShowPanel()
    {
        if (_centerEyeAnchor == null)
            return;

        // Calculate the position in front of the camera
        Vector3 newPosition = _centerEyeAnchor.transform.position +
                              _centerEyeAnchor.transform.right * offset.x +
                              _centerEyeAnchor.transform.up * offset.y +
                              _centerEyeAnchor.transform.forward * offset.z;

        // Set the panel's position
        panel.transform.position = newPosition;

        // Calculate the direction to look at (y-axis only)
        Vector3 direction = newPosition - _centerEyeAnchor.transform.position;
        direction.y = 0; // Only care about y-axis rotation

        // Set the panel's rotation to face the camera
        panel.transform.rotation = Quaternion.LookRotation(direction);

        // Activate the panel
        panel.SetActive(true);
    }
}