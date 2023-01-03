using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClikcMenuBar : MonoBehaviour
{
    public GameObject HandOverContents;
    public GameObject StartBtn;
    
    public void on_click_EMR(){
        HandOverContents.SetActive(true);
    }

    public void on_click_StartBtn(){
        HandOverContents.SetActive(false);
    }
}
