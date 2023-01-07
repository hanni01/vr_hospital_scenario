using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniContorller : MonoBehaviour
{
    public Animator par;
    public GameObject LoadingBarObj;
    
    // Start is called before the first frame update
    void Start()
    {
        par = GetComponent<Animator>();
    }

    // Update is called once per frame
   
    void Update(){
        if(LoadingBarObj.activeSelf == true){
        par.SetBool("Falling",true);
    }
    if(LoadingBarObj.activeSelf == false){
        par.SetBool("Falling",false);
    }
    }
}
