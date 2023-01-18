using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class talk_scene5 : MonoBehaviour
{
    public GameObject talk_canvas1;
    public GameObject talk_canvas3;
    public GameObject talk_canvas5;
    public GameObject talk_canvas6;
    public GameObject talk_canvas7;
    public GameObject talk_canvas9;
    public GameObject talk_canvas9_info;
    public bool scene5Done = false;
    public GameObject Answer_canvas2;
    public GameObject Answer_canvas4;
    public GameObject Answer_canvas8;

    public GameObject cup;
    public GameObject magazine;

    public Animator charAnimator;

    private void Update() {
        if(GameObject.Find("Talk4").GetComponent<talk_scene4>().scene4Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk4").GetComponent<talk_scene4>().scene4Done = false;
        }
    }

    public void canvas1_1_clicked()
    {
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        charAnimator.SetBool("HEAD", true);
        Answer_canvas2.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas2));
        talk_canvas3.SetActive(true);

        chekScore.PO1_17+= 1;
    }

    public void canvas1_2_clicked()
    {
        talk_canvas1.SetActive(false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas4.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas4));
        talk_canvas5.SetActive(true);

        chekScore.badScore+= 1;
    }

    public void canvas3_clicked()
    {
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        Answer_canvas4.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas4));
        talk_canvas5.SetActive(true);
    }

    public void canvas5_1_clicked()
    {
        charAnimator.SetBool("HEAD", false);
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);

        chekScore.PO3_14+= 1;
    }

    public void canvas5_2_clicked()
    {
        charAnimator.SetBool("HEAD", false);
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
        cup.SetActive(true);
        magazine.SetActive(true);
        StartCoroutine(sleep_on(talk_canvas9_info));

        chekScore.badScore+= 1;
    }

    public void canvas6_1_clicked()
    {
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
        talk_canvas7.SetActive(true);

        chekScore.PO3_11+= 1;
    }

    public void canvas6_2_clicked()
    {
        talk_canvas6.SetActive(false);
        for(int i = 0;i < 2;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
        cup.SetActive(true);
        magazine.SetActive(true);
        StartCoroutine(sleep_on(talk_canvas9_info));

        chekScore.badScore+= 1;
    }
    public void canvas7_clicked()
    {
        talk_canvas7.SetActive(false);
        LordingDegreePlus();
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
        cup.SetActive(true);
        magazine.SetActive(true);
        StartCoroutine(sleep_on(talk_canvas9_info));
    }

    public void Inspection_done_clicked()
    {
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        if(cup.activeSelf || magazine.activeSelf)
        {
            AudioSource incorrect = GameObject.Find("Talk5").GetComponent<AudioSource>();
            incorrect.Play();
        }else
        {
            chekScore.PO1_3+= 1;
        }
        scene5Done = true;
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