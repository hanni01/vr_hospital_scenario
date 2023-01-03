using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class totalRank : MonoBehaviour
{
    public Image commuDone;
    public Image orderDone;
    public Image processDone;
    private bool comm;
    private bool btnclickB;
    private bool degreeB;
    public TextMeshProUGUI totalRankTxt;
    public GameObject okButton;

    private void Update() {
        if(GameObject.Find("CommunicationCanvas").GetComponent<on_click_menu>().communication)
        {
            commuDone.color = new Color(255, 255, 255, 255);
            comm = true;
        }else
        {
            comm = false;
            commuDone.color = new Color(0, 0, 0, 255);
        }
        if(GameObject.Find("VP_MenuCanvas").GetComponent<onClickOrder>().btn_clicked)
        {
            orderDone.color = new Color(255, 255, 255, 255);
            btnclickB = true;
        }else
        {
            btnclickB = false;
            orderDone.color = new Color(0, 0, 0, 255);
        }
        if(GameObject.Find("Canvas_Progress").GetComponent<Overall_Progress>().degree == 1f)
        {
            processDone.color = new Color(255, 255, 255, 255);
            degreeB = true;
        }else
        {
            degreeB = false;
            processDone.color = new Color(0, 0, 0, 255);
        }

        if(comm && btnclickB && degreeB)
        {
            totalRankTxt.text = "A";
        }else if(!comm || !btnclickB || !degreeB)
        {
            totalRankTxt.text = "B";
        }
        else
        {
            totalRankTxt.text = "F";
        }
    }
    
    public void onClickOkBtn()
    {
        SceneManager.LoadScene("Demo Scene");
    }
}
