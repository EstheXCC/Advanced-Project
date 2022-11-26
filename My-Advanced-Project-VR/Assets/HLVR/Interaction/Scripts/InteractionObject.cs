using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HLVR.Event;


namespace HLVR.Interaction
{
    [DisallowMultipleComponent]//禁止重复添加
    [RequireComponent(typeof(AudioSource))]//链接AU组件
    public class InteractionObject : MonoBehaviour
    {
        public AudioSource audios;
        public IOAudioClip iOAudio;
        public ButtonEvent m_ButtonEvent;
        public Interaction m_RayStateEvent;
        bool enter = true;
        bool exit;
        RectTransform rectTransform;


        private void Start()
        {
           
            rectTransform = GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                if (transform.GetComponent<BoxCollider>() == null) 
                {
                    transform.gameObject.AddComponent<BoxCollider>();
                    transform.GetComponent<BoxCollider>().size = new Vector3(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y, 0);
                }
           
            }
          //  transform.tag = "IO";

            if (audios == null)
                audios = GetComponent<AudioSource>();
        }
        public void ResetState()
        {
            enter = true;
            exit = false;
        }
        public void Enter()
        {
            if (enter)
            {
                m_RayStateEvent.RayEnter?.Invoke();
                Debug.LogWarning("射线进入了"+transform.name);
                enter = false;
                exit = true;
                if (iOAudio.rayenter != null)
                    audios?.PlayOneShot(iOAudio.rayenter);
            }
        }
        public void Stay(bool keystate)
        {
            m_RayStateEvent.RayStay?.Invoke();
            if (keystate)
            {
                m_ButtonEvent.Button?.Invoke();
                if (iOAudio.buttonKey != null)
                    audios?.PlayOneShot(iOAudio.buttonKey);
                if (!m_ButtonEvent.oestate)
                {
                    m_ButtonEvent.ButtonOdd?.Invoke();
                    m_ButtonEvent.oestate = true;
                }
                else
                {
                    m_ButtonEvent.ButtonEven?.Invoke();
                    m_ButtonEvent.oestate = false;
                }
            }
        }

        public void Exit()
        {
            Debug.LogWarning("射线离开了" + transform.name);
            if (exit)
            {
                m_RayStateEvent.RayExit?.Invoke();
                exit = false;
                enter = true;
                if (iOAudio.rayexit != null)
                    audios?.PlayOneShot(iOAudio.rayexit);
            }
        }
    }

    [System.Serializable]
    public struct ButtonEvent
    {
        //[HideInInspector]
        //public AudioClip buttonKey;
        [Header("按下相应按键执行")]
        public InteractionEvent Button;//一直
        [Header("按下相应按键单数次执行")]
        public InteractionEvent ButtonOdd;//单数
        [Header("按下相应按键偶数次执行")]
        public InteractionEvent ButtonEven;//偶数
        [HideInInspector]
        public bool oestate;

    }

    [System.Serializable]
    public struct Interaction
    {
        //[HideInInspector]
        //public AudioClip enter;
        public InteractionEvent RayEnter;
        public InteractionEvent RayStay;
        //[HideInInspector]
        //public AudioClip exit;
        public InteractionEvent RayExit;
    }

    [System.Serializable]
    public struct IOAudioClip
    {
        public AudioClip buttonKey;
        public AudioClip rayenter;
        public AudioClip rayexit;
    }
}

