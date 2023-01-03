using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animaa2;

    public GameObject aniMess3;

    void Start()
    {
        animaa2 = GetComponent<Animator>();
    }


    public void nurseGO(){
        aniMess3.SetActive(true);
    }

    IEnumerator LittleWait()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
