using System;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Interaction;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button == null)
        {
            Debug.LogError("Button not assigned in UIManager");
            return;
        }

        if(OVRInput.GetUp(OVRInput.Button.Four))
        {
            button.onClick.Invoke();
        };
    }
}
