using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class ControllerInputsHandler : MonoBehaviour
{
    // TODO:

    // 1.Get hold of the Grab Interactor
    // 2.Get hold of the Controller Ref
    // 3.Get hold of the Grab Interactable
    // 4.Get in controller inputs
    // 5.Send inputs to the grabbed interactable

    private OVRInput.Button IndexTriggerAsButton => _controllerRef.Handedness == Handedness.Left ? OVRInput.Button.PrimaryIndexTrigger : OVRInput.Button.SecondaryIndexTrigger;
    private OVRInput.Axis1D IndexTriggerAsAxis1D => _controllerRef.Handedness == Handedness.Left ? OVRInput.Axis1D.PrimaryIndexTrigger : OVRInput.Axis1D.SecondaryIndexTrigger;
    private OVRInput.Axis2D ThumbstickAsAxis2D => _controllerRef.Handedness == Handedness.Left ? OVRInput.Axis2D.PrimaryThumbstick : OVRInput.Axis2D.PrimaryThumbstick;

    [SerializeField] private ControllerRef _controllerRef;
    [SerializeField] private GrabInteractor _grabInteractor;

    private GrabInteractable _grabInteractable;
    private IControllerButtonInputReceiver _controllerButtonInputReceiver;
    private IControllerAxis1DInputReceiver _controllerAxis1DInputReceiver;
    private IControllerAxis2DInputReceiver _controllerAxis2DInputReceiver;
    
    private void Update()
    {
        // _grabInteractor has any interactable object, else return
        if (!_grabInteractor.HasSelectedInteractable)
        {
            _grabInteractable = null;
            _controllerButtonInputReceiver = null;
            _controllerAxis1DInputReceiver = null;
            _controllerAxis2DInputReceiver = null;
            return;
        }
        

        if (_grabInteractable == null)
            _grabInteractable = _grabInteractor.SelectedInteractable;

        ReadInputs();
    }

    private void ReadInputs()
    {
        // Index Trigger as a button
        // bool isPressed = OVRInput.Get(IndexTriggerAsButton);
        // HandleButton(isPressed, IndexTriggerAsButton);
        HandleButton(OVRInput.Get(IndexTriggerAsButton), IndexTriggerAsButton);

        // Index trigger as an Axis1D
        HandleAxis1D(OVRInput.Get(IndexTriggerAsAxis1D), IndexTriggerAsAxis1D);

        // Thumbstick as an Axis2D
        HandleAxis2D(OVRInput.Get(ThumbstickAsAxis2D), ThumbstickAsAxis2D);
    }

    private void HandleButton(bool isPressed, OVRInput.Button button)
    {
        if (_controllerButtonInputReceiver == null)
        {  
            if (_grabInteractable.TryGetComponent(out IControllerButtonInputReceiver buttonInputReceiver))
            {
                buttonInputReceiver.ReciveInput(isPressed, button);
            }
        }
        
        
        if (_controllerButtonInputReceiver != null)
        {
            _controllerButtonInputReceiver.ReciveInput(isPressed, button);
        }
    }

    private void HandleAxis1D(float value, OVRInput.Axis1D axis1D)
    {   
        if (_controllerAxis1DInputReceiver == null)
        {
            if (_grabInteractable.TryGetComponent(out IControllerAxis1DInputReceiver axis1DInputReceiver))
            {
                axis1DInputReceiver.ReciveInput(value, axis1D);
            }
        }
        
        if (_controllerAxis1DInputReceiver != null)
        {
            _controllerAxis1DInputReceiver.ReciveInput(value, axis1D);
        }
        
    }

    private void HandleAxis2D(Vector2 value, OVRInput.Axis2D axis2D)
    {
        if (_controllerAxis2DInputReceiver == null)
        {
            if (_grabInteractable.TryGetComponent(out IControllerAxis2DInputReceiver axis2DInputReceiver))
            {
                axis2DInputReceiver.ReciveInput(value, axis2D);
            }
        }
        
        if (_controllerAxis2DInputReceiver != null)
        {
            _controllerAxis2DInputReceiver.ReciveInput(value, axis2D);
        }
    }
}
