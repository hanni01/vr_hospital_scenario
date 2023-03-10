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

    public Animator chrAnimator;

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
        chrAnimator.SetBool("HEAD", true);
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
        chrAnimator.SetBool("Angry", false);
        LordingDegreePlus();
        talk_canvas5.SetActive(true);

        chekScore.PO1_17+= 1;
    }

    public void canvas4_2_clicked()
    {
        Answer_canvas3.SetActive(false);
        talk_canvas4.SetActive(false);
        chrAnimator.SetBool("Angry", false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        talk_canvas6.SetActive(true);

        chekScore.badScore+= 1;
    }
    public void canvas5_1_clicked()
    {
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);

        chekScore.PO3_12+= 1;
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

        chekScore.badScore+= 1;
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
        LordingDegreePlus();
        yield return new WaitForSeconds(5.0f);
        obj.SetActive(false);
    }

    IEnumerator wait_next(GameObject obj)
    {
        chrAnimator.SetBool("HEAD", false);
        chrAnimator.SetBool("Angry", true);
        LordingDegreePlus();
        yield return new WaitForSeconds(15.0f);
        obj.SetActive(false);
        Answer_canvas3.SetActive(true);
        StartCoroutine(twice(Answer_canvas3));
        talk_canvas4.SetActive(true);
    }

    IEnumerator twice(GameObject obj)
    {
        yield return new WaitForSeconds(10.0f);
        StartCoroutine(sleep_on(obj));
    }

    public void LordingDegreePlus()
    {
        GameObject.Find("ProgressUI").GetComponent<Overall_Progress>().degree += 1; 
    }
}