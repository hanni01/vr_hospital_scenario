using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badEnding : MonoBehaviour
{
    public void replay_clicked()
    {
        SceneManager.LoadScene("Hospital Scene");

    }

    public void end_clicked()
    {
        Application.Quit();
    }
}
