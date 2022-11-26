using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralRectControl : MonoBehaviour
{
    public Vector3LerpStateCentral pos, angle, scale;
    RectControl[] rectControl;
    public void SetRectControl()
    {
        rectControl = new RectControl[transform.childCount];
        for (int i=0;i<rectControl.Length;i++)
        {
            rectControl[i] =transform.GetChild(i). GetComponent<RectControl>();
            rectControl[i].pos.m_TarState = pos.m_TarState;
            rectControl[i].pos.time = pos.time;
            rectControl[i].angle.m_TarState = angle.m_TarState;
            rectControl[i].angle.time = angle.time;
            rectControl[i].scale.m_TarState = scale.m_TarState;
            rectControl[i].scale.time = scale.time;
        }
    }
}

[System.Serializable]
public struct Vector3LerpStateCentral 
{
    public Vector3 m_TarState;
    [Range(1, 5)]
    public float time;
}
