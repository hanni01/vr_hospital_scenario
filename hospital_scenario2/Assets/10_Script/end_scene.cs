using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_scene : MonoBehaviour
{
    public GameObject endInfo_canvas;
    public GameObject result_canvas;
    public GameObject replayOrEnd_canvas;

    public void resultBtn_clicked()
    {
        endInfo_canvas.SetActive(false);
        result_canvas.SetActive(true);
    }

    public void check_done_clicked()
    {
        result_canvas.SetActive(false);
        replayOrEnd_canvas.SetActive(true);
    }

    public void replay_clicked()
    {
        SceneManager.LoadScene("Hospital Scene");

    }

    public void end_clicked()
    {
        Application.Quit();
    }
}
