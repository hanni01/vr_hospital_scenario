using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IKType
{
    ikWeight, weightBody, weightHead, ikLHandPosWeight, ikRHandPosWeight, ikLHandRotWeight, ikRHandRotWeight
}

public class AnimIKTest : MonoBehaviour
{
    
    public Animator animator;

    [Header("IK Active")]
    public bool ikActive;
    public bool ikBody, ikHand;

    [Header("IK Weight")]
    public float ikWeight;
    public float weightBody, weightHead, ikLHandPosWeight, ikRHandPosWeight, ikLHandRotWeight, ikRHandRotWeight;

    [Header("IK Target")]
    [Space(20)]
    public Transform HeadTarget;
    public Transform LhandTarget, RhandTarget;


    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }


    private void OnAnimatorIK()
    {
        if (ikActive)
        {
            if (ikBody)
            {
                animator.SetLookAtWeight(ikWeight, weightBody, weightHead, 1, 1);
                animator.SetLookAtPosition(HeadTarget.transform.position);
            }


            if (ikHand)
            {
                animator.SetIKPosition(AvatarIKGoal.LeftHand, LhandTarget.transform.position);
                animator.SetIKPosition(AvatarIKGoal.RightHand, RhandTarget.transform.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, LhandTarget.transform.rotation);
                animator.SetIKRotation(AvatarIKGoal.RightHand, RhandTarget.transform.rotation);

                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikRHandPosWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, ikRHandRotWeight);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikLHandPosWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, ikLHandRotWeight);
            }

        }
    }



    public void CoroutineIKSeperate(IKType iKType, bool _up, float _durationTime, float _speed, float _weight)
    {
        StartCoroutine(IKSeperteUpdate(iKType, _up, _durationTime, _speed, _weight));
    }



    public IEnumerator IKSeperteUpdate(IKType iKType, bool _up, float _durationTime, float _speed, float _weight)
    {
        bool start = true;
        float elapsed = 0;
        float currentWeight = 0;

        if (!_up)
        {
            if (iKType == IKType.ikWeight)
                currentWeight = ikWeight;
            else if (iKType == IKType.weightBody)
                currentWeight = weightBody;
            else if (iKType == IKType.weightHead)
                currentWeight = weightHead;
            else if (iKType == IKType.ikLHandPosWeight)
                currentWeight = ikLHandPosWeight;
            else if (iKType == IKType.ikRHandPosWeight)
                currentWeight = ikRHandPosWeight;
            else if (iKType == IKType.ikLHandRotWeight)
                currentWeight = ikLHandRotWeight;
            else if (iKType == IKType.ikRHandRotWeight)
                currentWeight = ikRHandRotWeight;
        }



        while (start)
        {
            elapsed += Time.deltaTime * _speed;
            float normalised = Mathf.Lerp(0, 1, elapsed / _durationTime);

            if (iKType == IKType.ikWeight)
                ikWeight = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.weightBody)
                weightBody = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.weightHead)
                weightHead = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.ikLHandPosWeight)
                ikLHandPosWeight = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.ikRHandPosWeight)
                ikRHandPosWeight = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.ikLHandRotWeight)
                ikLHandRotWeight = Mathf.Lerp(currentWeight, _weight, normalised);
            else if (iKType == IKType.ikRHandRotWeight)
                ikRHandRotWeight = Mathf.Lerp(currentWeight, _weight, normalised);

            if (normalised >= 0.99f)
            {
                start = false;
            }

            yield return new WaitForFixedUpdate();
        }
    }


    public void ResetIK()
    {
        ikActive = false;
        ikBody = false;
        ikHand = false;

        ikWeight = 0;
        weightBody = 0;
        weightHead = 0;
        ikRHandPosWeight = 0;
        ikRHandRotWeight = 0;
        ikLHandPosWeight = 0;
        ikLHandRotWeight = 0;
    }

}
