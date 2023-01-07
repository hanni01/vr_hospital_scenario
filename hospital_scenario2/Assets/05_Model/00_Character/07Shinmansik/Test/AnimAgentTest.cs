using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AnimAgentTest : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float agentRotSpeed = 10;
    public float distanceTarget = 0.2f;

    [Space(10)]
    public float explainTime = 3;

    public Animator patienrAnimator, doctorAnimator;
    
    [Space(10)]
    public AnimIKTest patientAnimAgentIK; 
    public AnimIKTest doctorAnimAgentIK;

    [Space(10)]
    public Transform destinationBed;
    public Transform destinationDoor;


    [Space(10)]
    public Transform doctorHead;
    public Transform PatientHeadTarget, TabletPC;
    public Transform PatientBedLhand, PatientBedRhand;
    public Transform SignPos, PatientRhandPos;
    public Transform DoctorBody, DoctorLHand, DoctorRHand;



    bool isWhile = true;


    void Walk(Animator animator, NavMeshAgent agent, Transform target)
    {

        agent.SetDestination(target.transform.position);


        if (Vector3.Distance(target.transform.position, agent.transform.position) >= distanceTarget)
        {
            Vector3 lookrotation = agent.steeringTarget - agent.transform.position;

            if (agent.desiredVelocity != Vector3.zero)
                agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(lookrotation), agentRotSpeed * Time.deltaTime);
        }


        if (Vector3.Distance(target.transform.position, agent.transform.position) < distanceTarget)
        {
            Debug.Log("도착");
            Rotate(agent);
            isWhile = false;
        }
    }


    void Rotate(NavMeshAgent agent)
    {
        agent.enabled = false;
        agent.transform.rotation = target.transform.rotation;
        agent.enabled = true;
    }



    IEnumerator OperateAgreement()
    {
        patientAnimAgentIK.ResetIK();
        doctorAnimAgentIK.ResetIK();

        doctorAnimator.SetBool("SignComplete", false);
        doctorAnimator.SetBool("ExplainComplete", false);
        doctorAnimator.SetBool("Explain", false);

        PatientBedRhand.position = PatientRhandPos.position;
        PatientHeadTarget.position = doctorHead.position;

        doctorAnimator.gameObject.transform.position = destinationDoor.transform.position;
        doctorAnimator.gameObject.transform.rotation = destinationDoor.transform.rotation;

        doctorAnimator.gameObject.SetActive(true);

        isWhile = true;

        target = destinationBed;

        if (agent == null)
            agent = doctorAnimator.GetComponent<NavMeshAgent>();

        // ------------------------------------------------------------------------------------------

        doctorAnimator.SetBool("Walk", true);
        doctorAnimator.Play("Walk");

        doctorAnimAgentIK.HeadTarget = DoctorBody;
        doctorAnimAgentIK.ikActive = true;
        doctorAnimAgentIK.ikBody = true;

        doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, true, 2, 1f, 1f);
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.weightBody, true, 2, 1f, 0.3f);
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.weightHead, true, 2, 1f, 0.6f);

        while (isWhile)
        {
            Walk(doctorAnimator, agent, target);

            yield return new WaitForFixedUpdate();
        }

        doctorAnimator.SetBool("Walk", false);


        yield return new WaitForSeconds(2);

        doctorAnimator.SetBool("Explain", true);


        patientAnimAgentIK.ikActive = true;
        patientAnimAgentIK.ikBody = true;
        patientAnimAgentIK.ikHand = true;

        patientAnimAgentIK.HeadTarget = PatientHeadTarget;
        patientAnimAgentIK.LhandTarget = PatientBedLhand;
        patientAnimAgentIK.RhandTarget = PatientBedRhand;

        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, true, 2, 2f, 1f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.weightBody, true, 2, 2f, 0.1f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.weightHead, true, 2, 2f, 1f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandPosWeight, true, 2, 1f, 1f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandRotWeight, true, 2, 1f, 1f);

        yield return new WaitForSeconds(explainTime);
        doctorAnimator.SetBool("ExplainComplete", true);
    

        isWhile = true;
        while (isWhile)
        {
            float step = 0.2f * Time.deltaTime;
            PatientHeadTarget.position = Vector3.MoveTowards(PatientHeadTarget.position, TabletPC.position, step);

            if (Vector3.Distance(PatientHeadTarget.position, TabletPC.position) < 0.01f)
                isWhile = false;

            yield return new WaitForFixedUpdate();
        }

        doctorAnimator.SetBool("Explain", false);


        isWhile = true;

        while (isWhile)
        {
            float step = 0.2f * Time.deltaTime; 
            PatientHeadTarget.position = Vector3.MoveTowards(PatientHeadTarget.position, TabletPC.position, step);

            if (doctorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Show"))
            {
                doctorAnimAgentIK.ikActive = true;
                doctorAnimAgentIK.ikBody = true;
                doctorAnimAgentIK.ikHand = true;

                doctorAnimAgentIK.HeadTarget = DoctorBody;
                doctorAnimAgentIK.LhandTarget = DoctorLHand;
                doctorAnimAgentIK.RhandTarget = DoctorRHand;


                doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, false, 2, 2f, 1f);
                doctorAnimAgentIK.CoroutineIKSeperate(IKType.weightBody, false, 2, 2f, 1f);
                doctorAnimAgentIK.CoroutineIKSeperate(IKType.weightHead, false, 2, 2f, 0.6f);

                doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandPosWeight, true, 2, 1f, 1f);
                doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandRotWeight, true, 2, 1f, 1f);

                isWhile = false;
            }
            yield return new WaitForFixedUpdate();

        }

        isWhile = true;

        while (isWhile)
        {
            float step = 0.2f * Time.deltaTime;
            PatientHeadTarget.position = Vector3.MoveTowards(PatientHeadTarget.position, TabletPC.position, step);

            if (Vector3.Distance(PatientHeadTarget.position, TabletPC.position) < 0.01f)
            {
                yield return new WaitForSeconds(5);
                isWhile = false;
            }
            yield return new WaitForFixedUpdate();
        }

        isWhile = true;

        patienrAnimator.SetBool("Signature", true);

        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikRHandPosWeight, false, 2, 0.5f, 0f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikRHandRotWeight, false, 2, 0.5f, 0f);

        while (isWhile)
        {
            float step = 0.7f * Time.deltaTime;
            PatientBedRhand.position = Vector3.MoveTowards(PatientBedRhand.position, SignPos.position, step);

            if (patienrAnimator.GetCurrentAnimatorStateInfo(0).IsName("Signature"))
            {
                if (patienrAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    isWhile = false;
                    Debug.Log("싸인을 끝냄");
                }
            }

            yield return new WaitForFixedUpdate();
        }


        // 동의서 작성완료 회수 퇴장
        doctorAnimator.SetBool("SignComplete", true);
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, false, 3, 1f, 0.5f);
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandPosWeight, false, 3, 1.1f, 0f);
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandRotWeight, false, 3, 1f, 0f);

        yield return new WaitForSeconds(3f);
        patienrAnimator.SetBool("Signature", false);

        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, false, 1, 1f, 0f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandPosWeight, false, 1, 1f, 0f);
        patientAnimAgentIK.CoroutineIKSeperate(IKType.ikLHandRotWeight, false, 1, 1f, 0f);

        yield return new WaitForSeconds(3f);

        isWhile = true;

        target = destinationDoor;
        doctorAnimAgentIK.CoroutineIKSeperate(IKType.ikWeight, false, 2, 1f, 0f);

        yield return new WaitForSeconds(5f);

        bool end = true;

        while (isWhile)
        {
            if (patientAnimAgentIK.ikWeight <= 0.1f && end)
            {
                doctorAnimator.SetBool("Walk", true);
                doctorAnimator.Play("Walk");
                doctorAnimAgentIK.ikActive = false;
                end = false;
            }

            if (!end)
                Walk(doctorAnimator, agent, target);

            yield return new WaitForFixedUpdate();
        }

        doctorAnimator.gameObject.SetActive(false);
    }


    private void OnGUI()
    {

        if (GUI.Button(new Rect(10, 200, 70, 25), "동의서 작성"))
        {
            Debug.Log("동의서 작성");
            StartCoroutine(OperateAgreement());
        }
    }

}
