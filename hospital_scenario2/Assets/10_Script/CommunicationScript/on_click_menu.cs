using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class on_click_menu : MonoBehaviour
{
    public GameObject talk;
    public GameObject introtalk;
    public GameObject patient_info_talk;
    public GameObject nameTalk;
    public GameObject birthTalk;
    public GameObject pastTalk;
    public GameObject mainPainTalk;
    public GameObject nameResponse;
    public GameObject birthResponse;
    public GameObject pastResponse;
    public GameObject mainPainResponse;
    public GameObject backbtn;
    public bool communication;
    public void talk_cliked(){
        talk.SetActive(false);
        introtalk.SetActive(true);
    }
    public void introtalk_clicked(){
        introtalk.SetActive(false);
        patient_info_talk.SetActive(true);
    }

    public void patient_info_name_clicked(){
        patient_info_talk.SetActive(false);
        
        nameResponse.SetActive(true);
        StartCoroutine(sleep_on(nameResponse));
        patient_info_talk.SetActive(true);
    }

    public void patient_info_birth_clicked(){
        patient_info_talk.SetActive(false);
        
        birthResponse.SetActive(true);
        StartCoroutine(sleep_on(birthResponse));
        patient_info_talk.SetActive(true);
    }

    public void patient_info_past_clicked(){
        patient_info_talk.SetActive(false);

        pastResponse.SetActive(true);
        StartCoroutine(sleep_on(pastResponse));
        patient_info_talk.SetActive(true);
    }

    public void patient_info_mainPain_clicked(){
        patient_info_talk.SetActive(false);

        mainPainResponse.SetActive(true);
        StartCoroutine(sleep_on(mainPainResponse));
        patient_info_talk.SetActive(true);
    }

    public void backbtn_clicked(){
        patient_info_talk.SetActive(false);
        talk.SetActive(true);
        communication = true;
    }

    IEnumerator sleep_on(GameObject obj){
        yield return new WaitForSeconds(4.0f);

        obj.SetActive(false);

    }   
}
