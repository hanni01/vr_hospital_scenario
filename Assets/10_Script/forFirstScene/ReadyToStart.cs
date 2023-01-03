using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToStart : MonoBehaviour
{
    public GameObject FirstInfoCanvas;
    public GameObject startBtn;
    public GameObject ArrowImage;
    public GameObject PressA;

    public void onClick_StartBtn()
    {
        FirstInfoCanvas.SetActive(false);
        ArrowImage.SetActive(true);
        PressA.SetActive(true);
    }
}
