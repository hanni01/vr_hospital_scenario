using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class talk_scene7 : MonoBehaviour
{
    public GameObject talk_canvas1;
    public GameObject talk_canvas3;
    public bool scene7Done = false;
    public GameObject Answer_canvas2;

    private void Update() {
        if(GameObject.Find("Talk6").GetComponent<talk_scene6>().scene6Done)
        {
            GameObject.Find("Talk6").GetComponent<talk_scene6>().Answer_canvas7.SetActive(false);
            talk_canvas1.SetActive(true);
            GameObject.Find("Talk6").GetComponent<talk_scene6>().scene6Done = false;
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

    public void canvas3_clicked()
    {
        Answer_canvas2.SetActive(false);
        talk_canvas3.SetActive(false);
        LordingDegreePlus();
        SceneManager.LoadScene("finish scene");
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