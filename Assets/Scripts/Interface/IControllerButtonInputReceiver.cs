using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerButtonInputReceiver
{
    public void ReciveInput(bool isPressed, OVRInput.Button button);
}
