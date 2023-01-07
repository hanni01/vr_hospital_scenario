using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{
    public Image LoadingBar;
    public GameObject LoadingBarObj;
    float currentValue;
    public float speed;
    public GameObject doneTxt;
    public GameObject cup;
    public GameObject medd;
    public GameObject aniMess;
    public GameObject aniMess2;

    void Update()
    {
        if(LoadingBarObj.activeSelf == true){
            if(currentValue < 100)
            {
                currentValue += speed * Time.deltaTime;
            }
            else
            {
                LoadingBarObj.SetActive(false);
                doneTxt.SetActive(true);
                StartCoroutine(delayTime(doneTxt));

                
                if(GameObject.Find("Canvas_Progress").GetComponent<Overall_Progress>().degree > 0.1f 
                && GameObject.Find("Canvas_Progress").GetComponent<Overall_Progress>().degree < 0.5f)
                {
                    cup.SetActive(true);
                    medd.SetActive(true);
                    aniMess.SetActive(true);
                }
                else if(GameObject.Find("Canvas_Progress").GetComponent<Overall_Progress>().degree == 1f)
                {
                    aniMess2.SetActive(true);
                }
            }
            LoadingBar.fillAmount = currentValue / 100;
        }else{
            currentValue = 0;
            LoadingBar.fillAmount = 0;
        }
    }

    IEnumerator delayTime (GameObject obj){
        yield return new WaitForSeconds(2.0f);

        obj.SetActive(false);

    }
}
