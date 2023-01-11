using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update() {
        if(GameObject.Find("Talk3").GetComponent<talk_scene3>().scene3Done)
        {
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk3").GetComponent<talk_scene3>().scene3Done = false;
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
        for(int i = 0;i < 6;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }

    public void canvas5_1_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        LordingDegreePlus();
        Answer_canvas6.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas6));
        talk_canvas7.SetActive(true);
    }

    public void canvas5_2_clicked()
    {
        Answer_canvas4.SetActive(false);
        talk_canvas5.SetActive(false);
        for(int i = 0;i < 3;i++)
        {
            LordingDegreePlus();
        }
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }

    public void canvas7_clicked()
    {
        talk_canvas7.SetActive(false);
        LordingDegreePlus();
        Answer_canvas8.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas8));
        talk_canvas9.SetActive(true);
    }
    public void canvas9_clicked()
    {
        Answer_canvas8.SetActive(false);
        talk_canvas9.SetActive(false);
        LordingDegreePlus();
        Answer_canvas10.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas10));
        talk_canvas11.SetActive(true);
    }

    public void canvas11_clicked()
    {
        Answer_canvas10.SetActive(false);
        talk_canvas11.SetActive(false);
        LordingDegreePlus();
        talk_canvasX3.SetActive(true);
    }

    public void canvasX3_clicked()
    {
        talk_canvasX3.SetActive(false);
        LordingDegreePlus();
        Answer_canvas14.SetActive(true);
        StartCoroutine(sleep_on(Answer_canvas14));
        talk_canvas15.SetActive(true);
    }

    public void canvas15_clicked()
    {
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
        scene4Done = true;
    }

    public void canvas19_clicked()
    {
        Answer_canvas18.SetActive(false);
        talk_canvas19.SetActive(false);
        LordingDegreePlus();
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
        Answer_canvas22.SetActive(false);
        talk_canvas23.SetActive(false);
        LordingDegreePlus();
        scene4Done = true;
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