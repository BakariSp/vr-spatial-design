using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerAxis2DInputReceiver
{
    public void ReciveInput(Vector2 value, OVRInput.Axis2D axis2D);
}
