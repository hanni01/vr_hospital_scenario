using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class talk_scene3 : MonoBehaviour
{
    public GameObject talk_canvas1;
    public GameObject talk_canvas3;
    public GameObject talk_canvas5;
    public GameObject talk_canvas6;
    public GameObject talk_canvas7;
    public GameObject talk_canvas9;
    public GameObject talk_canvas10;
    public bool scene3Done = false;

    public GameObject Answer_canvas2;
    public GameObject Answer_canvas4;
    public GameObject Answer_canvas8;

    public Animator CharAnimator;

    private void Update() {
        if(GameObject.Find("Talk").GetComponent<Talk>().scene2Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk").GetComponent<Talk>().scene2Done = false;
        }
    }

    public void canvas1_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "3_1_btn1")
        {
            chekScore.PO1_2 += 1;
            chekScore.PO3_8 += 1;
        }
        else
        {
            chekScore.badScore++;
        }
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        Answer_canvas2.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas2));
        talk_canvas3.SetActive(true);
    }
    public void canvas3_1_clicked()
    {
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        Answer_canvas4.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas4));
        talk_canvas5.SetActive(true);

        chekScore.PO3_10 += 1;
    }

    public void canvas3_2_clicked()
    {
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        for(int i = 0;i < 4;i++)
        {
            LordingDegreePlus();
        }
        talk_canvas7.SetActive(true);

        chekScore.badScore += 1;
    }

    public void canvas5_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "3_5_btn1")
        {
            chekScore.PO3_14 += 1;
        }
        else
        {
            chekScore.badScore += 1;
        }
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);
    }

    public void canvas6_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "3_6_btn1")
        {
            chekScore.PO3_11 += 1;
        }
        else
        {
            chekScore.badScore += 1;
        }
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
        talk_canvas7.SetActive(true);
    }
    public void canvas7_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas7.SetActive(false);
        LordingDegreePlus();
        CharAnimator.SetBool("NO", true);
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }

    public void canvas9_1_clicked()
    {
        CharAnimator.SetBool("NO", false);
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        LordingDegreePlus();
        talk_canvas10.SetActive(true);

        chekScore.PO3_9 += 1;
    }

    public void canvas9_2_clicked()
    {
        CharAnimator.SetBool("NO", false);
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        for(int i = 0;i < 2;i++)
        {
            LordingDegreePlus();
        }
        scene3Done = true;

        chekScore.badScore += 1;
    }

    public void canvas10_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "3_10_btn1")
        {
            chekScore.PO3_11 += 1;
        }
        else
        {
            chekScore.badScore += 1;
        }
        talk_canvas10.SetActive(false);
        LordingDegreePlus();
        scene3Done = true;
    }

    IEnumerator sleep_on(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        LordingDegreePlus();
        obj.SetActive(false);
    }

    public void LordingDegreePlus()
    {
        GameObject.Find("ProgressUI").GetComponent<Overall_Progress>().degree += 1;
    }
}