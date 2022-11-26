using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HLVR.Interaction;

[DisallowMultipleComponent]
public class RectControl : MonoBehaviour
{
    public RectTransform rect;
    public Vector3LerpState pos,angle,scale;
    InteractionObject interactionObject;
    private void Awake()
    {
        interactionObject = GetComponent<InteractionObject>();
        if (rect == null)
         rect = GetComponent<RectTransform>();
        pos.m_OriginState = rect.anchoredPosition3D;
        pos.open = true;
        angle.m_OriginState = rect.eulerAngles;
        angle.open = true;
        scale.m_OriginState = rect.localScale;
        scale.open = true;
    }
    private void OnEnable()
    {
        interactionObject.m_RayStateEvent.RayEnter.AddListener(Go);
        interactionObject.m_RayStateEvent.RayExit.AddListener(Back);
    }

    private void OnDisable()
    {
        interactionObject.m_RayStateEvent.RayEnter.RemoveListener(Go);
        interactionObject.m_RayStateEvent.RayExit.RemoveListener(Back);
    }

    void Go()
    {
        SetPosGo();
        SetAngleGo();
        SetScaleGo();
    }

    void Back()
    {
        SetPosBack();
        SetAngleBack();
        SetScaleBack();
    }
    private void Update()
    {
        LerpPos();
        LerpAngle();
        LerpScale();
    }
    void LerpPos()
    {
        if (pos.open) 
        {
            if (pos.Go)
            {
              
                rect.anchoredPosition3D = pos.LerpGo();
            }
            
            if (pos.Back)
            {
                rect.anchoredPosition3D = pos.LerpBack();
               
            }
        }
    }

    public void SetPosGo()
    {
        pos.Go = true;
        pos.Back = false;
    }

    public void SetPosBack()
    {
        pos.Go = false;
        pos.Back = true;
    }

    void LerpAngle()
    {
        if (angle.open)
        {
            if (angle.Go)
            {

                rect.eulerAngles = angle.LerpGo();
            }
           
            if (angle.Back)
            {
                rect.eulerAngles = angle.LerpBack();
            }
        }
    }
    public void SetAngleGo()
    {
        angle.Go = true;
        angle.Back = false;
    }

    public void SetAngleBack()
    {
        angle.Go = false;
        angle.Back = true;
    }

    void LerpScale()
    {
        if (scale.open)
        {
            if (scale.Go)
            {
                rect.localScale = scale.LerpGo();
            }
            else if (scale.Back)
            {
                rect.localScale = scale.LerpBack();
            }
        }
    }

    public void SetScaleGo()
    {
        scale.Go = true;
        scale.Back = false;
    }

    public void SetScaleBack()
    {
        scale.Go = false;
        scale.Back = true;
    }


}

[System.Serializable]
public struct Vector3LerpState
{
    public bool open;
    public bool Go
    {
        get;
        set;
    }
    public bool Back
    {
        get;
        set;
    }
    public Vector3 m_TarState;
    [Range(1, 5)]
    public float time;
    float lerp;
    [HideInInspector]
    public Vector3 m_OriginState;

     public Vector3 LerpGo()
     {
        lerp = Mathf.Clamp(lerp + Time.deltaTime*time, 0, 1);
       
        Vector3 value= Vector3.Lerp(m_OriginState, Add(), lerp);
        if (value == Add()) Go = false;
        return value;
     }

    public Vector3 LerpBack()
    {  
            lerp = Mathf.Clamp(lerp - Time.deltaTime * time, 0, 1);
        Debug.Log(lerp);
        Vector3 value = Vector3.Lerp(m_OriginState, Add(), lerp);
            if (value == m_OriginState) Back = false;
            return value;
    }
    public Vector3 Add() 
    {
        return m_OriginState + m_TarState;
    }
}
