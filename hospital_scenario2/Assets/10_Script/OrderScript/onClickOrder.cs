using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickOrder : MonoBehaviour
{
    public Image Tab_Order;
    public Image Tab_Treatment;
    public GameObject Order_all;
    public GameObject Treatment_all;
    public GameObject diet_btn;
    public GameObject general_order_diet;
    public Image checkImage;
    public bool btn_clicked = false;

    public void tab_order_clicked(){
        Tab_Order.color = new Color(11, 116, 249, 255);
        Tab_Treatment.color = new Color(11, 116, 249, 0);
        Treatment_all.SetActive(false);
        Order_all.SetActive(true);
    }

    public void tab_treatment_clicked(){
        Tab_Treatment.color = new Color(11, 116, 249, 225);
        Tab_Order.color = new Color(11, 116, 249, 0);
        Order_all.SetActive(false);
        Treatment_all.SetActive(true);
    }

    public void diet_btn_clicked(){
        if(btn_clicked == true){
            btn_clicked = false;
            checkImage.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            general_order_diet.SetActive(false);
        }else{
            btn_clicked = true;
            checkImage.GetComponent<Image>().color = new Color(0, 0, 0, 255);
            general_order_diet.SetActive(true);
        }
    }
}
