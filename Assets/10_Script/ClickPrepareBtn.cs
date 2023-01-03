using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPrepareBtn : MonoBehaviour
{
    public GameObject LoadingBarObj;
    public bool prepareDone;
    public GameObject prepareBtn;

    public void prepareBtn_clicked(){
        prepareDone = true;
        prepareBtn.SetActive(false);
        LoadingBarObj.SetActive(true);
    }
}
