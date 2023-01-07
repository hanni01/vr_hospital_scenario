using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prepareTrigger : MonoBehaviour
{
    public static bool sterilizeGrab = false;

    private void OnTriggerStay(Collider other) {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            sterilizeGrab = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        sterilizeGrab = false;
    }
}
