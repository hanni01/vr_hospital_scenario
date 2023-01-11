using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overall_Progress : MonoBehaviour
{
    public Image ProceduralImage;
    public Text Percentage;
    public int degree = 0;

    void Update()
    {
        ProceduralImage.fillAmount = (float)degree/66;
        int textValue = degree;
        Percentage.text = string.Format("{0:F1}",textValue.ToString()) + "/"+ " 66";
    }
}
