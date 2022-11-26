using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using  HLVR.Event;
namespace HLVR.Interaction 
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(LineRenderer))]
    public class InteractionRay : MonoBehaviour
    {
        [Tooltip("�������߹ر�")]
        public bool m_Enebled;
        [Tooltip("是否在交互开始的时候，手柄发生震动")]
        public bool m_OpenHandShake;
        public SteamVR_Input_Sources inputSource;
        public SteamVR_Action_Boolean button;
        [HideInInspector]
        public Ray ray;
        [HideInInspector]
        public RaycastHit hit;
        Transform leftHand, RightHand;
        [Tooltip("���߽����Ĳ㼶")]
        public LayerMask layerMask;
        [Tooltip("���߽����������Ч����")]
        public float m_MaxCastDistance;
        public float m_CastNullShowLength;
        [Header("������Ⱦ")]
        public RenderArguments m_RenderRay;
        LineRenderer line;
        InteractionObject m_IO;
        Teleport teleport;

        //public ShakeHand _shakeHand;
       // public InteractionEvent m_Response;// 交互响应事件
        #region
        public void SetEnebledState(bool state)
        {
            m_Enebled = state;
        }

        public void OpenEnebled()
        {
            m_Enebled = true;
        }

        public void CloseEnebled()
        {
            m_Enebled = false;
        }


        #endregion


        public enum RayShowType 
        {
           Every,
           KeyDown,
           HitCollider
        }

        public InteractionRay()
        {
            m_Enebled = true;
            inputSource = SteamVR_Input_Sources.Any;
            layerMask.value = 1;
            m_MaxCastDistance = 5;
            m_RenderRay.starwidth = 0.006f;
            m_RenderRay.endwidth = 0.0055f;
            m_RenderRay.normal = Color.red;
            m_RenderRay.hitIO = Color.yellow;
            if (m_RenderRay.material == null)
                Debug.LogWarning("���������Ӳ����򣬷������߽�ʹ��Ĭ�ϲ�����");
        }

        private void Awake()
        {
           
            teleport = GameObject.FindObjectOfType<Teleport>();
            print(button[inputSource].activeDevice);
            //if (_shakeHand!=null)
            //{
            //    _shakeHand.hand = inputSource;
            //}
            Initalize();
        }
        private void Initalize()//���ݳ�ʼ��
        {
            print(m_RenderRay.material);
            if (m_RenderRay.material == null) 
            {
                m_RenderRay.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended"));
            }
            line = GetComponent<LineRenderer>();
            GetHandType();//��ȡ�����ֱ�

        }
        private void LauchRay(Transform hand)//���߷���
        {
            ray = new Ray(hand.position, hand.forward);
        }

        private void OnEnable()
        {
            if (m_Enebled)
                Render.LineRenderState(line, true);
        }

        private void OnDisable()
        {
            Render.LineRenderState(line, false);
        }
        private void Update()
        {
            Run();
        }
        private void Run()//�߼�����
        {
            //��������
            LauchRay(GetHand());
            if (m_Enebled&& !teleport.teleportAction[inputSource].state&& button[inputSource].activeOrigin== button[inputSource].lastActiveOrigin)
            {
                //���߽������
                RayCastEvent();
                //��Ⱦ����
                Render.LineRenderState(line, true);
                Render.RenderTwoPointSegment(line, ray.origin, GetRayEndPoint(), m_RenderRay.starwidth, m_RenderRay.endwidth, m_RenderRay.material, m_RenderRay.gradient);
            }
            else
            {
                Render.LineRenderState(line, false);
            }
        }
        private void RayCastEvent()
        {
            //���߽������뿪���� ���������¼�

            if (RayCastState())
            {
                m_RenderRay.material.SetColor("_Color", m_RenderRay.hitIO);

                if (m_IO != null)
                {
                    //if (_shakeHand!=null)
                    //{
                    //    if (m_OpenHandShake)
                    //    {
                    //        m_IO.m_RayStateEvent.RayEnter.AddListener(_shakeHand.Shake);
                    //    }
                    //    // else
                    //    // {
                    //    //     m_IO.m_RayStateEvent.RayEnter.AddListener(_shakeHand.Shake);
                    //    // }
                       
                    //}
                   
                    if (m_IO.gameObject != hit.collider.gameObject)
                    {
                        m_IO.Exit();
                      //  m_IO.m_RayStateEvent.RayEnter.RemoveListener(_shakeHand.Shake);
                        m_IO = RayCastIO();
                    }
                    else
                    {
                        m_IO.Enter();
                        m_IO.Stay(button[inputSource].stateDown);
                    }
                }

                m_IO = RayCastIO();
            }
            else
            {
                if (m_IO != null)
                {
                    m_IO.Exit();
                  //  m_IO.m_RayStateEvent.RayEnter.RemoveListener(_shakeHand.Shake);
                    m_IO = null;
                }               
                m_RenderRay.material.SetColor("_Color", m_RenderRay.normal);
            }
        }

        public bool RayCastState()//������ײ״̬
        {
            if (Physics.Raycast(ray, out hit, m_MaxCastDistance, layerMask.value))
                return true;
            else return false;
        }

        private InteractionObject RayCastIO()//������ɽ�������Ľ���״̬
        {
            if (RayCastState())
            {
                if (hit.collider.gameObject.GetComponent<InteractionObject>() != null)
                    return hit.collider.gameObject.GetComponent<InteractionObject>();
                else return null;
            }
            else return null;
        }
        private Vector3 GetRayEndPoint()
        {
            //HLVR:��ȡ���ߵ��յ�����
            if (RayCastState())
                return hit.point;
            else
                return ray.GetPoint(m_MaxCastDistance* m_CastNullShowLength);
        }


        private Transform GetHand()
        {
            //HLVR:������������ڻ�ȡ���ֻ��������ĸ��ֲ��������ָ������----button
            if (button[inputSource].lastActiveOrigin == button[SteamVR_Input_Sources.LeftHand].lastActiveOrigin)
                return leftHand;
            else return RightHand;
        }
        private void GetHandType()
        {
            //HLVR:������������ڻ�ȡ���߷���Ĳο����ݼ�˫��
            Hand[] hands = GameObject.FindObjectsOfType<Hand>();
            for (int i = 0; i < hands.Length; i++)
            {
                if (hands[i].handType == SteamVR_Input_Sources.LeftHand)
                    leftHand = hands[i].transform;
                else
                    RightHand = hands[i].transform;
            }
        }
    }

    [System.Serializable]
    public struct RenderArguments
    {
        [Tooltip("���߿�ʼ���")]
        public float starwidth;
        [Tooltip("����β�����")]
        public float endwidth;
        [Tooltip("���߲�����")]
        public Material material;
        [Tooltip("���߽���ɫ")]
        [HideInInspector]
        public Gradient gradient;
       // [ColorUsage(true, true)]
        [Tooltip("����������ɫ")]
        public Color normal;
        [Tooltip("���߽�����ɫ")]
       // [ColorUsage(true, true)]
        public Color hitIO;
    }
}


