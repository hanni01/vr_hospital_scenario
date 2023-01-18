using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Talk : MonoBehaviour
{
    public GameObject talk_canvas;
    public GameObject talk_canvas1;
    public GameObject talk_canvas2;
    public GameObject talk_canvas3;
    public GameObject talk_canvas4;
    public GameObject talk_canvas5;
    public GameObject talk_canvas6;
    public bool scene2Done = false;

    public GameObject Answer_canvas1;
    public GameObject Answer_canvas2;
    public GameObject Answer_canvas3;

    AudioSource audioSource;
    public AudioClip correct;
    public AudioClip wrong;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();     
    }

    public void canvas_clicked()
    {
        talk_canvas.SetActive(false);
        LordingDegreePlus();
        talk_canvas1.SetActive(true);

        chekScore.PO1_1 += 1;
    }
    public void canvas1_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "2_1_btn1")
        {
            chekScore.PO1_2 += 1;
            chekScore.PO3_8 += 1;
        }else
        {
            chekScore.badScore += 1;
        }
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        Answer_canvas1.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas1));
        talk_canvas2.SetActive(true);
    }

    public void canvas2_clicked()
    {
        talk_canvas2.SetActive(false);
        LordingDegreePlus();
        Answer_canvas1.SetActive(false);
        Answer_canvas2.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas2));
        talk_canvas3.SetActive(true);
    }

    public void canvas3_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "2_5_btn1")
        {
            chekScore.PO3_9 += 1;
        }
        else{
            chekScore.badScore += 1;
        }
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        Answer_canvas2.SetActive(false);
        talk_canvas4.SetActive(true);
    }
    public void canvas4_clicked()
    {
        talk_canvas4.SetActive(false);
        LordingDegreePlus();
        Answer_canvas3.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas3));
        talk_canvas5.SetActive(true);
    }

    public void canvas5_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "Q1_btn1")
        {
            audioSource.clip = correct;
            audioSource.Play();

            chekScore.PO3_4 += 1;
        }
        else
        {
            audioSource.clip = wrong;
            audioSource.Play();

            chekScore.badScore += 1;
        }
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        talk_canvas6.SetActive(true);
    }

    public void canvas6_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "Q2_btn2")
        {
            audioSource.clip = correct;
            audioSource.Play();

            chekScore.PO3_5 += 1;
        }
        else
        {
            audioSource.clip = wrong;
            audioSource.Play();

            chekScore.badScore += 1;
        }
        talk_canvas6.SetActive(false);
        LordingDegreePlus();
        scene2Done = true;
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
