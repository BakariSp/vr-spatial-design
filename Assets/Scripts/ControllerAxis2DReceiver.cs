using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAxis2DReceiver : MonoBehaviour, IControllerAxis2DInputReceiver
{
    public event Action<Vector2, OVRInput.Axis2D> Axis2DInputReceived;
    public void ReciveInput(Vector2 value, OVRInput.Axis2D axis2D)
    {
        Axis2DInputReceived?.Invoke(value, axis2D);
    }
}
