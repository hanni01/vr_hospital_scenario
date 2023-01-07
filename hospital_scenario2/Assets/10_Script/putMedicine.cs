using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class putMedicine : MonoBehaviour
{
    public GameObject mark;
    public GameObject LoadingBarObj;
    public GameObject WarningMessage;
    public TextMeshProUGUI WarningTxt;
    public TextMeshProUGUI ProcessText;
    public bool waterDone = false;
    public bool medicineDone = false;

    void firstStepWater()
    {
        ProcessText.text = "step1: 식수 주입 완료";
        LoadingBarObj.SetActive(true);
        waterDone = true;
    }

    void secondStepM()
    {
        if(!waterDone)
        {
            WarningTxt.text = "!식수 단계부터 해주세요";
            WarningMessage.SetActive(true);
            StartCoroutine(sleep_oral(WarningMessage));
        }
        else
        {
            ProcessText.text = "step2: 투약 완료";
            LoadingBarObj.SetActive(true);
            medicineDone = true;
        }
    }

    IEnumerator sleep_oral(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);

        obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("collider ok~");

        mark.SetActive(true);
        if(other.name == "cup_with water")
        {
            firstStepWater();
        }
        else if(other.name == "PerOral001")
        {
            secondStepM();
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("collider no");
        LoadingBarObj.SetActive(false);
    }
    

}
