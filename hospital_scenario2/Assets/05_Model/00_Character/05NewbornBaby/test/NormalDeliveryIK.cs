using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NormalDeliveryNPCType
{
    Pregnant, Gynecologist, NewbornBaby
}

public class NormalDeliveryIK : MonoBehaviour
{
    public NormalDeliveryNPCType npcType;

    public bool ikActive = true;


    public bool ���οϷ� = false;
    public bool �Ʊ����� = false;
    public bool ��� = false;
    public bool ���� = false;
    public bool isStartDelivery = false;


    [Space(20)]
    [Header("�Ż��� Parent")]
    public bool babyWithGynecologist;
    public bool babyWithPregnant;


    [Space(20)]
    [Header("������ ���� ��ġ ����")]
    public bool TransformHipSet;
    public Vector3 posHipSocket;
    public Vector3 rotHipSocket;
    public Transform HipSocket;


    [Space(20)]
    [Header("����� ���� ��ġ ����")]
    public bool TransformBodySet;
    public Transform GynecologistRightHand;
    public Vector3 pos;
    public Vector3 rot;
    public Transform NewBornBabyBodySocket;

    [Space(20)]
    [Header("�Ż���")]
    public Animator IkAnimatorNewbornBaby;
    public Material matUmbilicalcord;
    public Material matBabyBody;

    [Space(20)]
    [Header("�ǻ�")]
    public Animator IkAnimatorGynecologist;
    public float IkWeightGynecologist;


    [Space(20)]
    [Header("��� ���ð�")]
    public bool TransformBodyWithPregnantSet;
    public Transform PregnantSpline;
    public Transform PregnantSocket;
    public Vector3 posPregnant;
    public Vector3 rotPregnant;
    public Transform lookBaby;
    [Range(0f, 1f)]
    public float weightLook = 1;
    [Range(0f, 1f)]
    public float weightBody = 0.15f;
    [Range(0f, 1f)]
    public float weightHead = 0.6f;
    [Range(0f, 1f)]
    public float weightHand = 0.3f;

    public Animator IkAnimatorPregnant;




    private void Awake()
    {
        if (npcType == NormalDeliveryNPCType.NewbornBaby)
            IkAnimatorNewbornBaby = GetComponent<Animator>();

        if (npcType == NormalDeliveryNPCType.Gynecologist)
            IkAnimatorGynecologist = GetComponent<Animator>();

        if (npcType == NormalDeliveryNPCType.Pregnant)
            IkAnimatorPregnant = GetComponent<Animator>();

        Initialize();
    }

    void Start()
    {

        babyWithGynecologist = true;
        babyWithPregnant = false;

        if (npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            TransformHipSet = true;
            TransformBodySet = true;
        }


        // �Ʊ� ��ġ ����
        if (babyWithGynecologist)
        {
            NewbornBabySetting();
        }
    }

    void NewbornBabySetting()
    {
        if (TransformHipSet && npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            Debug.Log("������ ��ġ ����");
            //HipSocket.transform.localEulerAngles = new Vector3(HipSocket.transform.localEulerAngles.x + rotHipSocket.x, HipSocket.transform.localEulerAngles.y + rotHipSocket.y, HipSocket.transform.localEulerAngles.z + rotHipSocket.z);
            HipSocket.transform.localPosition = new Vector3(posHipSocket.x, posHipSocket.y, posHipSocket.z);
            HipSocket.transform.localEulerAngles = new Vector3(rotHipSocket.x, rotHipSocket.y, rotHipSocket.z);

            TransformHipSet = false;
        }

        if (TransformBodySet && npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            Debug.Log("���� ��ġ ����");
            this.transform.parent = GynecologistRightHand;

            this.transform.position = GynecologistRightHand.position;
            this.transform.eulerAngles = GynecologistRightHand.eulerAngles;
            this.transform.localEulerAngles = new Vector3(rot.x, rot.y, rot.z);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + pos.x, this.transform.localPosition.y + pos.y, this.transform.localPosition.z + pos.z);


            TransformBodySet = false;
        }
    }




    public int randomNum = 3;

    void StartDelivery()
    {
        IkAnimatorGynecologist.SetBool("Change", true);
        IkAnimatorNewbornBaby.SetBool("Change", true);

        babyWithGynecologist = false;
        babyWithPregnant = true;
        TransformBodyWithPregnantSet = true;

        if (babyWithPregnant)
        {
            if (TransformBodyWithPregnantSet && npcType == NormalDeliveryNPCType.NewbornBaby)
            {
                Debug.Log("������� �Ѿ");

                Vector3 tRot = rotPregnant;
                Vector3 tPos = posPregnant;

                DeliverBaby(this.transform.localEulerAngles, tRot, this.transform.localPosition, tPos);// tPos));

                TransformBodyWithPregnantSet = false;
            }
        }

        isStartDelivery = false;
    }



    // �¾�����
    IEnumerator coroutineMove;
    public void DeliverBaby(Vector3 sRot, Vector3 tRot, Vector3 sPos, Vector3 tPos)
    {
        if (coroutineMove != null)
        {
            StopCoroutine(coroutineMove);
        }

        coroutineMove = Move(sRot, tRot, sPos, tPos);

        StartCoroutine(coroutineMove);
    }


    public IEnumerator Move(Vector3 sRot, Vector3 tRot, Vector3 sPos, Vector3 tPos)
    {
        bool start = true;

        this.transform.parent = PregnantSocket;

        IkAnimatorNewbornBaby.Play("Patient_NewbornBaby_Crying_Prone");


        float duration = 1.5f;
        float elapsed = 0;

        while (start)
        {

            if (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                //Debug.Log(elapsed);

                float normalised = Mathf.Lerp(0, 1, elapsed / duration);

                //Debug.Log(normalised);

                IkAnimatorNewbornBaby.SetFloat("Blend", Mathf.Lerp(0.3f, 1, normalised));
                transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, normalised);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, normalised);
                matUmbilicalcord.SetFloat("_Length", Mathf.Lerp(0.3f, 0.8f, normalised));// Mathf.Clamp01(normalised * 2)));

                if (normalised > 0.99f)
                    start = false;
            }
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.5f);


        Debug.Log("�̵� �Ϸ�");
        this.transform.parent.gameObject.transform.parent = PregnantSpline;




        StopCoroutine(coroutineMove);
    }








    private void OnAnimatorIK()
    {
        if (ikActive)
        {
            // ��� �ü� ó��
            if (lookBaby != null)
            {
                IkAnimatorPregnant.SetLookAtWeight(weightLook, weightBody, weightHead, 0, 1f);
                IkAnimatorPregnant.SetLookAtPosition(lookBaby.position);

                IkAnimatorPregnant.SetIKPositionWeight(AvatarIKGoal.RightHand, weightHand);
                IkAnimatorPregnant.SetIKRotationWeight(AvatarIKGoal.RightHand, weightHand);
                IkAnimatorPregnant.SetIKPositionWeight(AvatarIKGoal.LeftHand, weightHand);
                IkAnimatorPregnant.SetIKRotationWeight(AvatarIKGoal.LeftHand, weightHand);
            }


            // �ǻ� �޼� ó��
            if (npcType == NormalDeliveryNPCType.Gynecologist /*&& babyWithGynecologist*/)
            {
                IkAnimatorGynecologist.SetIKPositionWeight(AvatarIKGoal.LeftHand, IkWeightGynecologist);
                IkAnimatorGynecologist.SetIKRotationWeight(AvatarIKGoal.LeftHand, IkWeightGynecologist);
                IkAnimatorGynecologist.SetIKPosition(AvatarIKGoal.LeftHand, HipSocket.position);
                IkAnimatorGynecologist.SetIKRotation(AvatarIKGoal.LeftHand, HipSocket.rotation);
            }
        }
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 120, 30), "ó������ �ʱ�ȭ"))
        {
            Debug.Log("������ �ʱ�ȭ");
            IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().Initialize();
            IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().Initialize();
            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().Initialize();
        }


        // ���, ����, �ҵ��� �۱�, �¾� ����
        if (npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            if (GUI.Button(new Rect(10, 130, 120, 30), "���"))
            {
                ��� = true;
                UpUmbilicalCord();
            }

            if (GUI.Button(new Rect(10, 160, 120, 30), "����"))
            {
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().Cutting();
            }

            if (GUI.Button(new Rect(10, 100, 120, 30), "�ҵ��� �۱� 3��"))
            {
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().CleanBaby();
            }

            if (GUI.Button(new Rect(10, 70, 120, 30), "�Ʊ� ����"))
            {
                if (IkAnimatorNewbornBaby.GetBool("Absorption"))
                {
                    IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().DeliveryBaby();
                }
                else
                {
                    Debug.Log("������ ���� �ϼ���");
                    buttoneNameAbsorption = "������ ���� �ϼ���";
                }
            }


            if (GUI.Button(new Rect(10, 40, 120, 30), buttoneNameAbsorption))
            {
                ���οϷ� = true;
                Absorption();
                buttoneNameAbsorption = "���οϷ�";
            }

        }



        // ȫ�� ���긲
        if (npcType == NormalDeliveryNPCType.Pregnant)
        {
            if (GUI.Button(new Rect(10, 200, 180, 30), buttonNamePregnant))
            {
                IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().PregnantFace();
            }
        }

        // ���
        if (npcType == NormalDeliveryNPCType.Gynecologist)
        {
            if (GUI.Button(new Rect(10, 230, 120, 30), "���"))
            {
                StartCoroutine(Delivery());
            }
        }

    }


    // ���
    IEnumerator Delivery()
    {
        bool isEnd = true;
        IkAnimatorGynecologist.speed = 1f;


        while (isEnd)
        {
            if (IkAnimatorPregnant.GetCurrentAnimatorStateInfo(0).IsName("Patient_Pregnant_LithotomyPosition_Bed_Strength"))
            {
                Debug.Log("���ֱ� O");
                IkAnimatorPregnant.speed = 0.5f;

                // ���ֱ� ���¿��� ��� ����
                if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).IsName("MedicalStaff_Gynecologist_Treatment") )// && IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && IkAnimatorPregnant.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.2f)
                    {
                        IkAnimatorGynecologist.SetBool("Birth", true);
                        IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("Birth", true);

                        isEnd = false;
                    }
                }

            }
            else
            {
                Debug.Log("���ֱ� X");
            }

            yield return new WaitForFixedUpdate();
        }

        Debug.Log("��� ����");

        bool isBaby = true;
        while (isBaby)
        {
            if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).IsName("MedicalStaff_Gynecologist_TreatmentToSuction"))
            {
                IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().IkAnimatorNewbornBaby.gameObject.SetActive(true);
                isBaby = false;
            }
            yield return new WaitForFixedUpdate();
        }


        bool isStart = true;
        IkAnimatorPregnant.SetBool("IsStrength", true);

        while (isStart)
        {
            // ��� �ü�ó��, ��� �� �پ��
            Debug.Log(weightLook);
            weightLook += Time.deltaTime;

            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().weightLook = weightLook;
            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().Drape.SetBlendShapeWeight(0, Mathf.Lerp(0, 30, weightLook));
            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().PregnantBelly.SetBlendShapeWeight(1, Mathf.Lerp(100, 80, weightLook));
            IkAnimatorPregnant.speed = Mathf.Lerp(0.5f, 1f, weightLook);

            IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().IkWeightGynecologist = weightLook;

            if (weightLook >= 1)
            {
                weightLook = 1;
                isStart = false;
            }

            yield return new WaitForFixedUpdate();
        }

    }

    public SkinnedMeshRenderer Drape;
    public SkinnedMeshRenderer PregnantBelly;

    string buttoneNameAbsorption = "����";
    string buttonNamePregnant = "��� ���긲�� ȫ��";

    void Absorption()
    {
        if (���οϷ�)
        {
            IkAnimatorGynecologist.SetBool("Absorption", true);
            IkAnimatorNewbornBaby.SetBool("Absorption", true);
            IkAnimatorNewbornBaby.Play("Patient_NewbornBaby_Crying");
            ���οϷ� = false;
        }
    }

    void UpUmbilicalCord()
    {
        if (���)
        {
            IkAnimatorNewbornBaby.Play("Patient_NewbornBaby_UmbilicalCord_Up");
            ��� = false;
        }
    }

    void DeliveryBaby()
    {
        isStartDelivery = true;
        �Ʊ����� = true;

        if (�Ʊ�����)
        {
            IkAnimatorGynecologist.SetBool("Deliver", true);
            �Ʊ����� = false;
        }

        StartCoroutine(DeliveryBabyStart());
    }

    IEnumerator DeliveryBabyStart()
    {
        bool isStart = true;


        float duration = 1;
        float elapsed = 0;


        while (isStart)
        {
            if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).IsName("MedicalStaff_Gynecologist_DeliveryToPregnant_StartPut"))
            {

                IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().weightLook = Mathf.Lerp(1, 0f, IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).normalizedTime);

                if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    StartDelivery();
                    isStart = false;
                }


                // �ǻ� �޼� �¾ƿ��� ����߸���
                if (IkAnimatorGynecologist.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f /*&& isLHandGynecologistIKWeight*/)
                {

                    if (elapsed < duration)
                    {
                        elapsed += Time.deltaTime;
                        float normalised = Mathf.Lerp(1, 0, elapsed / duration);

                        IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().IkWeightGynecologist = normalised;
                    }

                }
            }

            yield return new WaitForFixedUpdate();
        }

        Debug.Log("���޿Ϸ�");

    }


    void CleanBaby()
    {
        // �ҵ��� �۱�, 3�� ����
        StartTextureBlend(matBabyBody, 3);

        IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("LHand", true);

    }


    IEnumerator coroutineTextureBlend;


    public Material MatPregnantBody;

    // ��� �� ȫ��, ���긲
    void PregnantFace()
    {
        // 5������?
        StartTextureBlend(MatPregnantBody, 5);
    }

    public void StartTextureBlend(Material _mat, float _duration)
    {
        if (coroutineTextureBlend != null)
        {
            StopCoroutine(coroutineTextureBlend);
        }

        coroutineTextureBlend = TextureBlend(_mat, _duration);

        StartCoroutine(coroutineTextureBlend);
    }

    // �Ʊ� �۱�
    public IEnumerator TextureBlend(Material _mat, float _duration)
    {
        bool start = true;

        float duration = _duration;
        float elapsed = 0;

        while (start)
        {

            if (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                //Debug.Log("time : " + elapsed);

                float normalised = Mathf.Lerp(0, 1, elapsed / duration);
                _mat.SetFloat("_BlendValue", Mathf.Lerp(0f, 1, normalised));

                if (normalised > 0.99f)
                {
                    start = false;
                }
            }
            yield return new WaitForFixedUpdate();
        }

        StopCoroutine(coroutineTextureBlend);
    }


    // ���� �ڸ���
    void Cutting()
    {
        matUmbilicalcord.SetFloat("_Length", 0.33f);
        matUmbilicalcord.SetFloat("_FadePow", 5f);
        matUmbilicalcord.SetFloat("_ColorTop", 1f);

        IkAnimatorNewbornBaby.Play("Patient_NewbornBaby_UmbilicalCord_CutDown");

        StartCoroutine(CuttingAfter());

    }

    public bool IsPregnantIdleChange = false;
    IEnumerator CuttingAfter()
    {
        Debug.Log("�̰� �ȵǳ�?");

        yield return new WaitForSeconds(2f);
        IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("RHand", true);

        while (true)
        {
            Debug.Log("ü������");


            Debug.Log("ü������");

            int num = Random.Range(0, randomNum);
            if (num == 0)
            {
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("TwoHand", true);
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("RHand", false);
            }
            else
            {
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("TwoHand", false);
                IkAnimatorNewbornBaby.GetComponent<NormalDeliveryIK>().IkAnimatorPregnant.SetBool("RHand", true);
            }

            yield return new WaitForSeconds(2f);

            //yield return new WaitForFixedUpdate();
        }

    }


    // ���� �ʱ�ȭ
    public void Initialize()
    {
        ��� = false;
        ���� = false;
        ���οϷ� = false;
        �Ʊ����� = false;
        isStartDelivery = false;


        if (npcType == NormalDeliveryNPCType.Gynecologist)
        {
            babyWithGynecologist = true;
            babyWithPregnant = false;
        }

        if (npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            babyWithGynecologist = true;
            babyWithPregnant = false;
        }



        if (npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            TransformHipSet = true;
            TransformBodySet = true;
            matBabyBody.SetFloat("_BlendValue", 0);
        }


        if (babyWithGynecologist)
        {
            NewbornBabySetting();
        }

        IkAnimatorGynecologist.SetBool("Change", false);
        IkAnimatorNewbornBaby.SetBool("Change", false);

        IkAnimatorGynecologist.SetBool("Absorption", false);
        IkAnimatorNewbornBaby.SetBool("Absorption", false);

        IkAnimatorGynecologist.SetBool("Deliver", false);
        IkAnimatorNewbornBaby.SetBool("Deliver", false);

        IkAnimatorGynecologist.SetBool("Birth", false);

        if (npcType == NormalDeliveryNPCType.NewbornBaby)
        {
            matUmbilicalcord.SetFloat("_Length", 0.3f);
            matUmbilicalcord.SetFloat("_FadePow", 2f);
            matUmbilicalcord.SetFloat("_ColorTop", 0f);
            matBabyBody.SetFloat("_BlendValue", 0);
            IkAnimatorNewbornBaby.Play("Patient_NewbornBaby_Idle");
        }

        if (npcType == NormalDeliveryNPCType.Pregnant)
        {
            IkAnimatorPregnant.speed = 1f;

            IkAnimatorPregnant.Play("Patient_Pregnant_LithotomyPosition_Inhalation");
            weightLook = 0;
            IkAnimatorPregnant.SetBool("Birth", false);

            IkAnimatorPregnant.SetBool("LHand", false);
            IkAnimatorPregnant.SetBool("RHand", false);
            IkAnimatorPregnant.SetBool("TwoHand", false);
            IkAnimatorPregnant.SetBool("IsStrength", false);
            MatPregnantBody.SetFloat("_BlendValue", 0);

            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().Drape.SetBlendShapeWeight(0, 0);
            IkAnimatorPregnant.GetComponent<NormalDeliveryIK>().PregnantBelly.SetBlendShapeWeight(1, 100);
        }

        if (npcType == NormalDeliveryNPCType.Gynecologist)
        {
            IkAnimatorGynecologist.Play("MedicalStaff_Gynecologist_Treatment");
            IkWeightGynecologist = 0;
            IkAnimatorGynecologist.speed = 1f;
            IkAnimatorGynecologist.GetComponent<NormalDeliveryIK>().IkAnimatorNewbornBaby.gameObject.SetActive(false);
        }

        weightLook = 0;

        buttoneNameAbsorption = "����";
    }

}
