using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatientCloth
{
    // 상하의 환자복
    DressWholeCloth,
    UndressWholeCloth,
    UndressUpperCloth,
    UndressLowerCloth/*,*/

    // 원피스 환자복
    //DressOnePieceCloth ////
    //UndressOnePieceCloth
}


public class PatientClothes : MonoBehaviour
{
    public PatientCloth patientCloth;

    public SkinnedMeshRenderer currentBody;

    //상하의 환자복
    public GameObject UpperCloth;
    public GameObject LowerCloth;

    public SkinnedMeshRenderer Body;
    public SkinnedMeshRenderer BodyClothes;
    public SkinnedMeshRenderer BodyUpper;
    public SkinnedMeshRenderer BodyLower;


    //원피스 환자복 추가




    public void ClothChange(PatientCloth _patientCloth)
    {
        bool pass = true;
        if (patientCloth == _patientCloth) pass = false;

        if (_patientCloth == PatientCloth.UndressLowerCloth || _patientCloth == PatientCloth.UndressUpperCloth)
        {
            if (patientCloth == PatientCloth.UndressWholeCloth) pass = false;
        }


        if (!pass) return;


        if (_patientCloth == PatientCloth.DressWholeCloth)
        {
            UpdateMeshRenderer(currentBody, BodyClothes);
            UpperCloth.SetActive(true);
            LowerCloth.SetActive(true);
        }
        else if (_patientCloth == PatientCloth.UndressWholeCloth)
        {
            UpdateMeshRenderer(currentBody, Body);
            UpperCloth.SetActive(false);
            LowerCloth.SetActive(false);
        }
        else if (_patientCloth == PatientCloth.UndressUpperCloth)
        {
            if (patientCloth == PatientCloth.UndressLowerCloth)
                UpdateMeshRenderer(currentBody, Body);
            else
                UpdateMeshRenderer(currentBody, BodyUpper);

            UpperCloth.SetActive(false);
        }
        else if (_patientCloth == PatientCloth.UndressLowerCloth)
        {
            if (patientCloth == PatientCloth.UndressUpperCloth)
                UpdateMeshRenderer(currentBody, Body);
            else
                UpdateMeshRenderer(currentBody, BodyLower);

            LowerCloth.SetActive(false);
        }

        patientCloth = _patientCloth;
    }



    public void UpdateMeshRenderer(SkinnedMeshRenderer _meshRenderer, SkinnedMeshRenderer _newMeshRenderer)//, bool materialChange = false)
    {

        SkinnedMeshRenderer meshrenderer = _meshRenderer;
        SkinnedMeshRenderer newMeshRenderer = _newMeshRenderer.GetComponentInChildren<SkinnedMeshRenderer>();
        meshrenderer.sharedMesh = newMeshRenderer.sharedMesh;

        Transform[] childrens = transform.GetComponentsInChildren<Transform>(true);

        Transform[] bones = new Transform[newMeshRenderer.bones.Length];
        for (int boneOrder = 0; boneOrder < newMeshRenderer.bones.Length; boneOrder++)
        {
            bones[boneOrder] = Array.Find<Transform>(childrens, c => c.name == newMeshRenderer.bones[boneOrder].name);
        }
        meshrenderer.bones = bones;
    }



}
