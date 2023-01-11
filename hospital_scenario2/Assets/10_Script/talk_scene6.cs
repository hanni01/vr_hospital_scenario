using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk_scene6 : MonoBehaviour
{
    public GameObject talk_canvas1;
    public GameObject talk_canvas4;
    public GameObject talk_canvas5;
    public GameObject talk_canvas6;
    public bool scene6Done = false;
    public GameObject Answer_canvas2;
    public GameObject Answer_canvas3;
    public GameObject Answer_canvas7;

    private void Update() {
        if(GameObject.Find("Talk5").GetComponent<talk_scene5>().scene5Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk5").GetComponent<talk_scene5>().scene5Done = false;
        }
    }

    public void canvas1_1_clicked()
    {
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        Answer_canvas2.SetActive(true);
        StartCoroutine(wait_next(Answer_canvas2));
    }

    public void canvas1_2_clicked()
    {
        talk_canvas1.SetActive(false);
        for(int i = 0;i < 7;i++)
        {
            LordingDegreePlus();
        }
        scene6Done = true;
    }

    public void canvas4_1_clicked()
    {
        Answer_canvas3.SetActive(false);
        talk_canvas4.SetActive(false);
        LordingDegreePlus();
        talk_canvas5.SetActive(true);
    }

    public void canvas4_2_clicked()
    {
        Answer_canvas3.SetActive(false);
        talk_canvas4.SetActive(false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        talk_canvas6.SetActive(true);
    }
    public void canvas5_1_clicked()
    {
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);
    }
    public void canvas5_2_clicked()
    {
        talk_canvas5.SetActive(false);
        for(int i = 0;i < 2;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas7.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas7));
        scene6Done = true;
    }
    public void canvas6clicked()
    {
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
        Answer_canvas7.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas7));
        scene6Done = true;
    }
    IEnumerator sleep_on(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        LordingDegreePlus();
        obj.SetActive(false);
    }

    IEnumerator wait_next(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        obj.SetActive(false);
        LordingDegreePlus();
        Answer_canvas3.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas3));
        talk_canvas4.SetActive(true);
    }

    public void LordingDegreePlus()
    {
        GameObject.Find("ProgressUI").GetComponent<Overall_Progress>().degree += 1; 
    }
}