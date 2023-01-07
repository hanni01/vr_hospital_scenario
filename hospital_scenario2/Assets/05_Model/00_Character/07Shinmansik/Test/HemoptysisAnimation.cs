using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HemoptysisAnimation : MonoBehaviour
{
    [Range(0, 1)]
    public float LightIntensityMultiplier = 1;
    public bool DecalLiveTimeInfinite = false;

    public AnimationCurve AnimationSpeed = AnimationCurve.Linear(0, 0, 1, 1);
    public float FramesCount = 99;
    public float TimeLimit = 3;
    public float OffsetFrames = 0;
    public float endTime = 0.5f;

    private float startTime;

    public Renderer rend;

    public Material mat;

    void Awake()
    {
        if (mat == null)
            mat = GetComponent<MeshRenderer>().sharedMaterial;

        if (rend == null)
            rend = GetComponent<Renderer>();

    }

    void OnEnable()
    {
        rend.enabled = true;

        mat.SetFloat("_UseCustomTime", 1.0f);
        mat.SetFloat("_TimeInFrames", 0.0f);

        startTime = Time.time;
    }

    void Update()
    {
        var currentTime = (Time.time - startTime) / TimeLimit;


        if (currentTime > endTime)
        {
            if (rend.enabled) rend.enabled = false;
            return;
        }

        var currentFrameTime = AnimationSpeed.Evaluate(currentTime);
        currentFrameTime = currentFrameTime * FramesCount + OffsetFrames + 1.1f;
        float timeInFrames = (Mathf.Ceil(-currentFrameTime) / (FramesCount + 1)) + (1.0f / (FramesCount + 1));

        mat.SetFloat("_LightIntencity", Mathf.Clamp(LightIntensityMultiplier, 0.01f, 1f));
        mat.SetFloat("_TimeInFrames", timeInFrames);
    }

}
