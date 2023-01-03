using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class prepareGrabbable : MonoBehaviour
{
    public GameObject LoadingBarObj;
    public GameObject SanitizerCapsule;
    private Rigidbody rb;
    private bool isGrab = false;
    public XRNode m_ControllerNode = XRNode.RightHand;
    public InputHelpers.Button m_SelectUsage = InputHelpers.Button.PrimaryButton;
    public GameObject SelectedModel;
    public bool isGrabPrepare = false;

    public XRNode controllerNode
    {
        get => m_ControllerNode;
        set => m_ControllerNode = value;
    }

    public InputHelpers.Button selectUsage
    {
        get => m_SelectUsage;
        set => m_SelectUsage = value;
    }

    InputDevice m_InputDevice;
    public InputDevice inputDevice => m_InputDevice.isValid ? m_InputDevice : m_InputDevice = InputDevices.GetDeviceAtXRNode(controllerNode);

    void Awake() {
        rb = SanitizerCapsule.GetComponent<Rigidbody>();
        if(!rb)
        {
            Debug.LogError("No rigidbody");
        }
    }

    void PressButtonGrab(InputHelpers.Button button)
    {
        inputDevice.IsPressed(button, out var pressed);
        if(pressed)
        {
            isGrabPrepare = true;
            Debug.Log("start prepare");
            LoadingBarObj.SetActive(true);
            SelectedModel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        SelectedModel.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        SelectedModel.SetActive(false);
    }

    private void OnTriggerStay(Collider other) {
        PressButtonGrab(m_SelectUsage);
    }

    
}
