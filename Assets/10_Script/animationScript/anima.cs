using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animaa;




    void Start()
    {
        animaa = GetComponent<Animator>();
    }


    

    IEnumerator LittleWait()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
