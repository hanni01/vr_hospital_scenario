using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedUpDown : MonoBehaviour
{
    public GameObject controlBtn;
    public GameObject LoadingBarObj;

    public Animator par;

    private void OnTriggerEnter(Collider other) {
        LoadingBarObj.SetActive(true);
        if(LoadingBarObj.activeSelf == false)
        {
            if(par.GetBool("Falling") == true){
                par.SetBool("Falling", false);
            }else{
                par.SetBool("Falling",true);
            }
        }
        
    }

    

}
