using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update() {
        if(GameObject.Find("Talk").GetComponent<Talk>().scene2Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk").GetComponent<Talk>().scene2Done = false;
        }
    }

    public void canvas1_clicked()
    {
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
    }

    public void canvas5_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);
    }

    public void canvas6_clicked()
    {
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
        talk_canvas7.SetActive(true);
    }
    public void canvas7_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas7.SetActive(false);
        LordingDegreePlus();
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }

    public void canvas9_1_clicked()
    {
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        LordingDegreePlus();
        talk_canvas10.SetActive(true);
    }

    public void canvas9_2_clicked()
    {
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        for(int i = 0;i < 2;i++)
        {
            LordingDegreePlus();
        }
        scene3Done = true;
    }

    public void canvas10_clicked()
    {
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