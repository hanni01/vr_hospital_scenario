using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOk : MonoBehaviour
{
    public GameObject check;
    public GameObject firstCanvas;
    public GameObject infoArrow;
    public void onClick_check()
    {
        firstCanvas.SetActive(false);
        infoArrow.SetActive(true);
    }
}
