using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerButtonReceiver : MonoBehaviour, IControllerButtonInputReceiver
{
    public event Action<bool, OVRInput.Button> ButtonInputReceived;
    public void ReciveInput(bool isPressed, OVRInput.Button button)
    {
        // Receive input
        ButtonInputReceived?.Invoke(isPressed, button);
    }
}
