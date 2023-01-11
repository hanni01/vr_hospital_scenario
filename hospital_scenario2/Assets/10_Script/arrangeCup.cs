using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class arrangeCup : MonoBehaviour
{
    public GameObject cup;
    private Rigidbody rb;
    public XRNode m_ControllerNode = XRNode.RightHand;
    public InputHelpers.Button m_SelectUsage = InputHelpers.Button.PrimaryButton;

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
        rb = cup.GetComponent<Rigidbody>();
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
            Debug.Log("start prepare");
            cup.SetActive(false);
            
            AudioSource correct = GameObject.Find("Arrange").GetComponent<AudioSource>();
            correct.Play();
        }
    }

    private void OnTriggerStay(Collider other) {
        PressButtonGrab(m_SelectUsage);
    }

    
}