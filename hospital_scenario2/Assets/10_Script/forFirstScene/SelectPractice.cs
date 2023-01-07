using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPractice : MonoBehaviour
{
    public GameObject warningM;
    public GameObject SelectedPractice;
    public GameObject SelectPracticeType;

    public void onClick_injection()
    {
        warningM.SetActive(true);
        Invoke("Delay", 2.0f);
    }

    public void onClick_Blood()
    {
        warningM.SetActive(true);
        Invoke("Delay", 2.0f);
    }

    public void onClick_Oxygen()
    {
        warningM.SetActive(true);
        Invoke("Delay", 2.0f);
    }

    public void onClick_Oral()
    {
        SelectPracticeType.SetActive(false);
        SelectedPractice.SetActive(true);
    }

    void Delay()
    {
        warningM.SetActive(false);
    }
}
