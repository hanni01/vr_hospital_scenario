using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabBracelet : MonoBehaviour
{
    public GameObject Bracelet;
    public GameObject SelectedBracelet;
    private Rigidbody rb;
    public XRNode m_ControllerNode = XRNode.RightHand;
    public InputHelpers.Button m_SelectUsage = InputHelpers.Button.PrimaryButton;
    public GameObject BraceletCanvas;
    public GameObject BraceletToolGuide;
    public GameObject HandSanitizerToolguide1;
    public GameObject HandSanitizerToolguide2;

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
        rb = Bracelet.GetComponent<Rigidbody>();
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
            BraceletCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        SelectedBracelet.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        SelectedBracelet.SetActive(false);
    }

    private void OnTriggerStay(Collider other) {
        PressButtonGrab(m_SelectUsage);
    }

    public void onClick_braceletBtn()
    {
        BraceletCanvas.SetActive(false);
        BraceletToolGuide.SetActive(false);
        HandSanitizerToolguide1.SetActive(true);
        HandSanitizerToolguide2.SetActive(true);
    }
}
