using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainTubeTest : MonoBehaviour
{
    [Header("Liquid Material")]
    public Material matLiquid;

    [Range(0.56f, 0.45f)]
    [Header("Liquid Length")]
    public float fillAmount;

    [Header("Liquid Simulation Properties")]
    public float MaxWobble = 0.05f;
    public float WobbleSpeed = 1f;
    public float Recovery = 1f;

    //
    Vector3 lastPos;
    Vector3 velocity;
    Vector3 lastRot;
    Vector3 angularVelocity;
    float wobbleAmountX;
    float wobbleAmountZ;
    float wobbleAmountToAddX;
    float wobbleAmountToAddZ;
    float pulse;
    float time = 0.5f;

    private void OnValidate()
    {
        //matLiquid.SetFloat("_Length", fillAmount);
    }


    private void LateUpdate()
    {
        if (matLiquid) return;
        // Liquid Length
        matLiquid.SetFloat("_Length", fillAmount);

        // ½Ã¹Ä·¹ÀÌ¼Ç
        time += Time.deltaTime;
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * Recovery);
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * Recovery);

        pulse = 2 * Mathf.PI * WobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        matLiquid.SetFloat("_WobbleX", wobbleAmountX);
        matLiquid.SetFloat("_WobbleZ", wobbleAmountZ);

        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;

        wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
        wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }
}
