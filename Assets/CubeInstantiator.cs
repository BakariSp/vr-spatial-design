using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform InitialPosition;
    [SerializeField] private ControllerButtonReceiver _controllerButtonReceiver;

    private void OnEnable()
    {
        _controllerButtonReceiver.ButtonInputReceived += OnButtonInputReceived;
    }

    private void OnDisable()
    {
        _controllerButtonReceiver.ButtonInputReceived -= OnButtonInputReceived;
    }

    private void OnButtonInputReceived(bool isPressed, OVRInput.Button button)
    {

        if (!isPressed)
            return;

        Instantiate(cubePrefab, InitialPosition.position, Quaternion.identity);
    }
}
