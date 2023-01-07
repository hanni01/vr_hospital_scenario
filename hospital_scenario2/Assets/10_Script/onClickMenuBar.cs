using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickMenuBar : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject checkCanvas;
    public GameObject totalRank;
    public GameObject checkBtn;
    public GameObject cancelBtn;

    public void onClickExitBtn()
    {
        checkCanvas.SetActive(true);
    }
    public void onClickCheckBtn()
    {
        checkCanvas.SetActive(false);
        totalRank.SetActive(true);
    }

    public void onClickCancelBtn()
    {
        checkCanvas.SetActive(false);
    }
}
