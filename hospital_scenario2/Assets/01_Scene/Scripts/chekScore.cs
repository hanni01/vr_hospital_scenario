using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chekScore : MonoBehaviour
{
    protected internal static int badScore = 0;
    protected internal static int PO1_1 = 0;
    protected internal static int PO1_2 = 0;
    protected internal static int PO1_3 = 0;
    protected internal static int PO1_17 = 0;
    protected internal static int PO1_20 = 0;
    protected internal static int PO3_4 = 0;
    protected internal static int PO3_5 = 0;
    protected internal static int PO3_8 = 0;
    protected internal static int PO3_9 = 0;
    protected internal static int PO3_10 = 0;
    protected internal static int PO3_11 = 0;
    protected internal static int PO3_12 = 0;
    protected internal static int PO3_13 = 0;
    protected internal static int PO3_14 = 0;

    public TextMeshProUGUI po1_1;
    public TextMeshProUGUI po1_2;
    public TextMeshProUGUI po1_3;
    public TextMeshProUGUI po1_17;
    public TextMeshProUGUI po1_20;
    public TextMeshProUGUI po3_4;
    public TextMeshProUGUI po3_5;
    public TextMeshProUGUI po3_8;
    public TextMeshProUGUI po3_9;
    public TextMeshProUGUI po3_10;
    public TextMeshProUGUI po3_11;
    public TextMeshProUGUI po3_12;
    public TextMeshProUGUI po3_13;
    public TextMeshProUGUI po3_14;
    public TextMeshProUGUI totalTxt;

    int total = 0;

    void Update()
    {
        po1_1.text = PO1_1+"/1";
        po1_2.text = PO1_2+"/2";
        po1_3.text = PO1_3+"/1";
        po3_4.text = PO3_4+"/1";
        po3_5.text = PO3_5+"/1";
        po3_8.text = PO3_8+"/3";
        po3_9.text = PO3_9+"/5";
        po3_10.text = PO3_10+"/1";
        po3_11.text = PO3_11+"/3";
        po3_12.text = PO3_12+"/2";
        po3_13.text = PO3_13+"/1";
        po3_14.text = PO3_14+"/4";
        po1_17.text = PO1_17+"/4";
        po1_20.text = PO1_20+"/1";

        total = PO1_1 + PO1_2 + PO1_3 + PO3_4 + PO3_5 + PO3_8 + PO3_9 + PO3_10 + PO3_11 + PO3_12 + PO3_13 + PO3_13 + PO3_14 + PO1_17 + PO1_20;

        totalTxt.text = total+"/30";

        Debug.Log("1_1 : "+PO1_1);
        Debug.Log("1_2 : "+PO1_1);
        Debug.Log(badScore);
    }
}
