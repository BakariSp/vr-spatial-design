using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerAxis1DInputReceiver
{
    public void ReciveInput(float isPressed, OVRInput.Axis1D axis1D);
}
