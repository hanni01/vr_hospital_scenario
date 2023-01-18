using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class talk_scene4 : MonoBehaviour
{
    public GameObject talk_canvas1;
    public GameObject talk_canvas3;
    public GameObject talk_canvas5;
    public GameObject talk_canvas7;
    public GameObject talk_canvas9;
    public GameObject talk_canvas11;
    public GameObject talk_canvasX3;
    public GameObject talk_canvas13;
    public GameObject talk_canvas15;
    public GameObject talk_canvas17;
    public GameObject talk_canvas19;
    public GameObject talk_canvas21;
    public GameObject talk_canvas23;
    public bool scene4Done = false;

    public GameObject Answer_canvas2;
    public GameObject Answer_canvas4;
    public GameObject Answer_canvas6;
    public GameObject Answer_canvas8;
    public GameObject Answer_canvas10;
    public GameObject Answer_canvasX2;
    public GameObject Answer_canvas12;
    public GameObject Answer_canvas14;
    public GameObject Answer_canvas16;
    public GameObject Answer_canvas18;
    public GameObject Answer_canvas20;
    public GameObject Answer_canvas22;
    public GameObject Answer_canvas8_1;

    public GameObject retryCanvas;
    public Animator charAnimator;

    private void Update() {
        if(GameObject.Find("Talk3").GetComponent<talk_scene3>().scene3Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk3").GetComponent<talk_scene3>().scene3Done = false;
        }
    }

    public void canvas1_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "4_1_btn1")
        {
            chekScore.PO1_20++;
            chekScore.PO3_8++;
        }
        else
        {
            chekScore.badScore++;
        }
        talk_canvas1.SetActive(false);
        LordingDegreePlus();
        charAnimator.SetBool("Angry", true);
        Answer_canvas2.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas2));
        talk_canvas3.SetActive(true);
    }
    public void canvas3_1_clicked()
    {
        charAnimator.SetBool("Angry", false);
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        Answer_canvas4.SetActive(true);
        charAnimator.SetBool("DownHead", true);
        StartCoroutine(sleep_on(Answer_canvas4));
        talk_canvas5.SetActive(true);

        chekScore.PO3_9++;
    }

    public void canvas3_2_clicked()
    {
        charAnimator.SetBool("Angry", false);
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        for(int i = 0;i < 6;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);

        chekScore.badScore++;
    }

    public void canvas5_1_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        Answer_canvas6.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas6));
        talk_canvas7.SetActive(true);

        chekScore.PO3_13++;
    }

    public void canvas5_2_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        charAnimator.SetBool("DownHead", false);
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);

        chekScore.badScore += 2;
    }

    public void canvas7_clicked()
    {
        talk_canvas7.SetActive(false);
        LordingDegreePlus();
        charAnimator.SetBool("DownHead", false);
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }
    public void canvas9_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "4_9_btn1")
        {
            chekScore.PO3_12++;
        }
        else
        {
            chekScore.badScore++;
        }
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        LordingDegreePlus();
        Answer_canvas10.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas10));
        talk_canvas11.SetActive(true);
    }

    public void canvas11_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "4_11_btn1")
        {
            chekScore.PO3_14+= 1;
        }
        else
        {
            chekScore.badScore+= 1;
        }
        Answer_canvas10.SetActive(false);
        talk_canvas11.SetActive(false);
        LordingDegreePlus();
        
        if(chekScore.badScore >= 2)
        {
            talk_canvasX3.SetActive(true);
            Debug.Log(chekScore.badScore+": badEnding cross");
            charAnimator.SetBool("HEAD", true);
        }
        else
        {
            Debug.Log(chekScore.badScore+": Not BadEnding cross");
            Answer_canvas12.SetActive(true);
            StartCoroutine(sleep_on(Answer_canvas12));
            talk_canvasX3.SetActive(true);

            charAnimator.SetBool("HEAD", true);
        }
    }

    public void canvasX3_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        
        talk_canvasX3.SetActive(false);
        charAnimator.SetBool("HEAD", false);
        LordingDegreePlus();

        if(clickObject.name == "X3_1_btn1")
        {
            chekScore.PO1_17+= 1;

            Answer_canvas14.SetActive(true);
            StartCoroutine(sleep_on(Answer_canvas14));
            talk_canvas15.SetActive(true);
        }
        else
        {
            if(chekScore.badScore >= 2)
            {
                Answer_canvas8_1.SetActive(true);
                StartCoroutine(badEnding(Answer_canvas8_1));
                Debug.Log("badEnding");
                charAnimator.SetBool("Angry", true);
            }
            else
            {
                chekScore.badScore+= 1;

                Answer_canvas14.SetActive(true);
                StartCoroutine(sleep_on(Answer_canvas14));
                talk_canvas15.SetActive(true);
                Debug.Log("Good");
            }
        }
    }

    public void canvas15_clicked()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if(clickObject.name == "4_15_btn1")
        {
            chekScore.PO1_17+= 1;
        }
        else
        {
            chekScore.badScore+= 1;
        }
        Answer_canvas14.SetActive(false);
        talk_canvas15.SetActive(false);
        LordingDegreePlus();
        Answer_canvas16.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas16));
        talk_canvas17.SetActive(true);
    }

    public void canvas17_1_clicked()
    {
        Answer_canvas16.SetActive(false);
        talk_canvas17.SetActive(false);
        LordingDegreePlus();
        Answer_canvas18.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas18));
        talk_canvas19.SetActive(true);

        chekScore.PO3_14+= 1;
    }

    public void canvas17_2_clicked()
    {
        Answer_canvas16.SetActive(false);
        talk_canvas17.SetActive(false);
        for(int i = 0;i < 7;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas16.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas16));

        chekScore.badScore+= 1;
        scene4Done = true;
    }

    public void canvas19_clicked()
    {
        Answer_canvas18.SetActive(false);
        talk_canvas19.SetActive(false);
        LordingDegreePlus();
        charAnimator.SetBool("DownHead", true);
        Answer_canvas20.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas20));
        talk_canvas21.SetActive(true);
    }

    public void canvas21_clicked()
    {
        Answer_canvas20.SetActive(false);
        talk_canvas21.SetActive(false);
        LordingDegreePlus();
        Answer_canvas22.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas22));
        talk_canvas23.SetActive(true);
    }

    public void canvas23_clicked()
    {
        charAnimator.SetBool("DownHead", false);
        Answer_canvas22.SetActive(false);
        talk_canvas23.SetActive(false);
        LordingDegreePlus();

        chekScore.PO3_9+= 1;
        scene4Done = true;
    }

    IEnumerator sleep_on(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        LordingDegreePlus();
        obj.SetActive(false);
    }

    IEnumerator badEnding(GameObject obj)
    {
        yield return new WaitForSeconds(4.0f);
        LordingDegreePlus();
        obj.SetActive(false);
        charAnimator.SetBool("Angry", false);

        retryCanvas.SetActive(true);
    }

    public void LordingDegreePlus()
    {
        GameObject.Find("ProgressUI").GetComponent<Overall_Progress>().degree += 1;
    }
}