using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class EsophagealVarixTest : MonoBehaviour
{
    public Camera maincamera;

    [Space(5)]
    [Header("부종 가로세로 사이즈 입력. 수치가 클수록 작아짐")]
    public Vector2 tileXY = new Vector2(50, 50);
    public Vector2 tileXYRandomSize;

    // 좌표값 및 위치 조정
    public Vector4[] offsetUV = new Vector4[4];
    Vector2 offsetUVModify = new Vector2(0.5f, 0.5f);

    [Header("부종 깊이값")]
    [Range(1, 2)]
    public float bumpScale = 1.3f;

    [Header("부종 머터리얼")]
    public Material material;

    [Header("현재 부종 넘버")]
    public int currentEdma = 0;


    // 눌렀을 때 들어가고 나오는 속도
    public float timeSpeed = 1;
    // 들어가는 시간, 다시 나오는 시간
    public float durationDownTime = 3, durationUpTime = 10;
    // 손을 떼고나서 1초후에 다시 원래 피부로 재생
    public float waitTime = 1;


    private void OnValidate()
    {
        if (maincamera == null)
            maincamera = Camera.main;

        if (material == null)
            material = GetComponent<MeshRenderer>().sharedMaterial;
    }


    void Start()
    {
        Initialize();

        patientCloth = GetComponent<PatientClothes>();
        animatior = GetComponent<Animator>();
    }

    //초기화
    void Initialize()
    {
        currentEdma = 3;
        offsetUV = new Vector4[4];
        for (int i = 0; i < 4; i++)
        {
            material.SetFloat("_Edma" + i.ToString(), 0);
            Debug.Log("_Edma" + i.ToString());
        }
    }



    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!EdemaTest)
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 100);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                //if (hit.collider.gameObject.name.Equals("leg"))
                //    Debug.Log(hit.collider.gameObject.name); //부종다리 meshCollider
                
                Vector2 _tileXY = new Vector2(tileXY.x + Random.Range(tileXYRandomSize.x, tileXYRandomSize.y), tileXY.y + Random.Range(tileXYRandomSize.x, tileXYRandomSize.y));

                if (currentEdma == 3)
                {
                    if (coroutineEdma[0] != null)
                        StopCoroutine(coroutineEdma[0]);

                    currentEdma = 0;
                }
                else
                    currentEdma++;

                offsetUV[currentEdma] = hit.textureCoord2;

                offsetUV[currentEdma].x *= -_tileXY.x;
                offsetUV[currentEdma].y *= -_tileXY.y;

                offsetUV[currentEdma].x += offsetUVModify.x;
                offsetUV[currentEdma].y += offsetUVModify.y;


                string Edma = "_Edma" + currentEdma.ToString();
                string HitTex = "_HitTex" + currentEdma.ToString();
                string AlphaTex = "_AlphaTex" + currentEdma.ToString();
                string Num = "_Num" + currentEdma.ToString();
                string Fade = "_Fade" + currentEdma.ToString();
            

                Debug.Log("부종 Size" + _tileXY.x);
                Debug.Log("좌표값" + offsetUV);

                material.SetFloat(Edma, 1);
                material.SetTextureScale(HitTex, new Vector2(_tileXY.x, _tileXY.y));
                material.SetTextureOffset(HitTex, offsetUV[currentEdma]);

                material.SetTextureScale(AlphaTex, new Vector2(_tileXY.x, _tileXY.y));
                material.SetTextureOffset(AlphaTex, offsetUV[currentEdma]);

                material.SetInt(Num, (int)Random.Range(1, 4));
                material.SetFloat("_BumpEdmaScale", bumpScale);

                EdmaPlay(Fade, Edma);
            }
        }
    }

    

    IEnumerator[] coroutineEdma = new IEnumerator[4];

    public void EdmaPlay(string _Fade, string _edma)
    {
        if (coroutineEdma[currentEdma] != null)
            StopCoroutine(coroutineEdma[currentEdma]);

        coroutineEdma[currentEdma] = EdmaCoroutine(_Fade, _edma);//, coroutineIdlePlay[currentEdma]);
        StartCoroutine(coroutineEdma[currentEdma]);
    }


    IEnumerator EdmaCoroutine(string _Fade, string Edma)//, IEnumerator _conroutine)
    {
        float elapsed = 0;
        bool down = true;

        float _durationDownTime = durationDownTime;
        float _durationUpTime = durationUpTime;
        while (down)
        {
            elapsed += Time.deltaTime * timeSpeed;
            float normalised = Mathf.Lerp(1, 0, elapsed / _durationDownTime);
            material.SetFloat(_Fade, Mathf.Lerp(1f, 0f, normalised));

            if (normalised <= 0)
            {
                down = false;
            }

            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Edema Down complete");

        yield return new WaitForSeconds(waitTime);

        elapsed = 0;
        bool Up = true;


        while (Up)
        {
            elapsed += Time.deltaTime * timeSpeed;
            float normalised = Mathf.Lerp(0, 1, elapsed / _durationUpTime);
            material.SetFloat(_Fade, Mathf.Lerp(1f, 0f, normalised));

            if (normalised >= 1f)
            {
                Up = false;
            }

            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Edema Up complete");

        material.SetFloat(Edma, 0);
    }



    // 손가락에 충돌박스로 처리...
    //void OnCollisionEnter(Collision collisionInfo)
    //{
    //    foreach (ContactPoint cp in collisionInfo.contacts)
    //    {
    //        RaycastHit hit;
    //    }
    //}



    public PatientClothes patientCloth;
    public bool EdemaTest = false;
    public Animator animatior;


    public float guiPosX;

    private void OnGUI()
    {

        if (GUI.Button(new Rect(10 + guiPosX, 10, 57, 20), "환자복O"))
        {
            patientCloth.ClothChange(PatientCloth.DressWholeCloth);
        }

        if (GUI.Button(new Rect(70 + guiPosX, 10, 57, 20), "환자복X"))
        {
            patientCloth.ClothChange(PatientCloth.UndressWholeCloth);
        }

        if (GUI.Button(new Rect(10 + guiPosX, 40, 55, 20), "상의X"))
        {
            patientCloth.ClothChange(PatientCloth.UndressUpperCloth);
        }

        if (GUI.Button(new Rect(70 + guiPosX, 40, 55, 20), "하의X"))
        {
            patientCloth.ClothChange(PatientCloth.UndressLowerCloth);
        }



        if (GUI.Button(new Rect(10 + guiPosX, 70, 70, 25), "부종사정"))
        {
            EdemaTest = true;
        }

        if (GUI.Button(new Rect(10 + guiPosX, 100, 70, 25), "울렁거림"))
        {
            animatior.SetBool("EsophagealVarix_Pain", true);
            animatior.SetBool("EsophagealVarix_Idle", false);
        }

        if (GUI.Button(new Rect(10 + guiPosX, 130, 70, 25), "토혈"))
        {
            animatior.SetBool("EsophagealVarix_Hemoptysis", true);
        }


        if (GUI.Button(new Rect(10 + guiPosX, 160, 70, 25), "환자눕힘"))
        {
            animatior.SetBool("EsophagealVarix_Idle", true);
            animatior.SetBool("EsophagealVarix_Pain", false);
            animatior.SetBool("EsophagealVarix_Hemoptysis", false);
            animatior.GetComponent<Hemoptysis>().ResetClothEffect();
        }


    }


}
