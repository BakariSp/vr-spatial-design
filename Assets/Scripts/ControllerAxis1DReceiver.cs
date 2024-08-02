using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAxis1DReceiver : MonoBehaviour, IControllerAxis1DInputReceiver
{
    public event Action<float, OVRInput.Axis1D> Axis1DInputReceived;
    public void ReciveInput(float value, OVRInput.Axis1D axis1D)
    {
       Axis1DInputReceived?.Invoke(value, axis1D);
    }
    
}
