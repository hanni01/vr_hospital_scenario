using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickHandOver : MonoBehaviour
{
    public GameObject HandOverContents;
    public GameObject StartBtn;
    public GameObject scene2Arrow;
    public AudioSource audioSource;
    public GameObject infoCommuAndBracelet;
    public GameObject ToolGuide;
    public void on_click_EMR(){
        HandOverContents.SetActive(true);
        scene2Arrow.SetActive(false);
    }

    public void on_click_StartBtn(){
        HandOverContents.SetActive(false);
        infoCommuAndBracelet.SetActive(true);
        audioSource.Play();
        ToolGuide.SetActive(true);
    }

    private void Update() {
        if(!audioSource.isPlaying)
        {
            infoCommuAndBracelet.SetActive(false);
        }
    }
}
