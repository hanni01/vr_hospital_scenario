using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overall_Progress : MonoBehaviour
{
    public Image ProceduralImage;
    public Text Percentage;
    public float degree = 0;

    void Update()
    {
        ProceduralImage.fillAmount = degree;
        float textValue = degree*100;
        Percentage.text = string.Format("{0:F1}",textValue.ToString()) + "%";

         if(degree > 1)
        {
            degree = 1f;
        }
        else
        {
            if(GameObject.Find("Talk").GetComponent<Talk>().LordingDegree)
            {
                degree += 1f / 66;
            }
            
        }
    }
}
