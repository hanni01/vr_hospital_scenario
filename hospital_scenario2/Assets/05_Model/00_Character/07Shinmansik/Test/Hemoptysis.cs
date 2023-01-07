using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hemoptysis : MonoBehaviour
{
    public Transform socket;
    public float socketAngle = -90;

    [Header("MainLight")]
    public Light DirLight;

    public GameObject BloodFX;

    public GameObject ClothFX;


    public float destroyTime = 8;
    public float durationTime = 2;

    //void Update()
    //{
    //    //if (chrAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > effectStartTime && Effect && chrAnimator.GetCurrentAnimatorStateInfo(0).IsName("EsophagealVarix_Hemoptysis"))
    //    //{
    //    //    var instance = Instantiate(BloodFX, socket.position, Quaternion.Euler(socket.rotation.x, socket.rotation.y + angle, socket.rotation.z));// Quaternion.Euler(0, angle + 90, 0));

    //    //    //var settings = instance.GetComponentInChildren<HemoptysisAnimation>();
    //    //    //settings.DecalLiveTimeInfinite = InfiniteDecal;


    //    //    if (!InfiniteDecal) Destroy(instance, 20);

    //    //    Effect = false;
    //    //}

    //    //if (chrAnimator.GetCurrentAnimatorStateInfo(0).IsName("EsophagealVarix_Pain"))
    //    //{
    //    //    Effect = true;
    //    //}
    //}




    // 애니메이션파일에 붙이는 걸로 변경
    void EffectHemoptysis()
    {
        Debug.Log("EffectHemoptysis. 토혈 이벤트");
        var instance = Instantiate(BloodFX, socket.position, Quaternion.Euler(socket.rotation.x, socket.rotation.y + socketAngle, socket.rotation.z));// Quaternion.Euler(0, angle + 90, 0));


        HemoptysisAnimation hemoptysisAnimation = instance.GetComponentInChildren<HemoptysisAnimation>();

        if (DirLight != null)
            hemoptysisAnimation.LightIntensityMultiplier = DirLight.intensity;
        else
            hemoptysisAnimation.LightIntensityMultiplier = 1;

        Destroy(instance, destroyTime);
    }


    // 애니메이션파일에 붙임
    void EffectBloodCloth()
    {
        Debug.Log("EffectBloodCloth. 옷에 피 묻힘 이벤트");

        Material mat =  ClothFX.GetComponent<SkinnedMeshRenderer>().sharedMaterial;

        StartCoroutine(ClothFXUpdate(mat));
        //mat.SetFloat("_BloodFade", time);
    }

    public float ClothFXTime;


    IEnumerator ClothFXUpdate(Material _mat)
    {
        bool start = true;
        float elapsed = 0;

        _mat.SetFloat("_Add", 1);

        while (start)
        {
            elapsed += Time.deltaTime * 2;
            float normalised = Mathf.Lerp(0, 1, elapsed / durationTime);
            _mat.SetFloat("_Fade", Mathf.Lerp(0f, 1f, normalised));

            if (normalised >= 1)
            {
                start = false;
            }
            yield return new WaitForFixedUpdate();
        }

    }

    public void ResetClothEffect()
    {
        Material mat = ClothFX.GetComponent<SkinnedMeshRenderer>().sharedMaterial;
        mat.SetFloat("_Fade", 0);
        mat.SetFloat("_Add", 0);
    }

}