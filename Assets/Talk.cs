using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public GameObject start_canvas;
    public GameObject start_canvas1;

    public GameObject talk_canvas;
    public GameObject talk_canvas1;
    public GameObject talk_canvas2;
    public GameObject talk_canvas3;
    public GameObject talk_canvas4;
    public GameObject talk_canvas5;
    public GameObject talk_canvas6;

    public GameObject Answer_canvas1;
    public GameObject Answer_canvas2;
    public GameObject Answer_canvas3;

    public bool LordingDegree = false;


    public void StartCanvas_clicked()
    {
        start_canvas.SetActive(false);
        start_canvas1.SetActive(true);
    }
    public void StartCanvas1_clicked()
    {
        start_canvas1.SetActive(false);
        talk_canvas.SetActive(true);
    }
    public void canvas_clicked()
    {
        talk_canvas.SetActive(false);
        LordingDegreePlus();
        talk_canvas1.SetActive(true);
    }
    public void canvas1_clicked()
    {
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        Answer_canvas1.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas1));
        LordingDegreePlus();
        talk_canvas2.SetActive(true);
    }

    public void canvas2_clicked()
    {
        talk_canvas2.SetActive(false);
        LordingDegreePlus();
        Answer_canvas2.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas2));
        LordingDegreePlus();
        talk_canvas3.SetActive(true);
    }

    public void canvas3_clicked()
    {
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        talk_canvas4.SetActive(true);
    }
    public void canvas4_clicked()
    {
        talk_canvas4.SetActive(false);
        LordingDegreePlus();
        Answer_canvas3.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas3));
        LordingDegreePlus();
        talk_canvas5.SetActive(true);
    }

    public void canvas5_clicked()
    {
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);
    }

    public void canvas6_clicked()
    {
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
    }

    IEnumerator sleep_on(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        obj.SetActive(false);
    }

    public void LordingDegreePlus()
    {
        LordingDegree = true;
        LordingDegree = false;
    }
}
