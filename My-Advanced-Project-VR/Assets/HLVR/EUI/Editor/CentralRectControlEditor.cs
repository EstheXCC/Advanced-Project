using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(CentralRectControl))]
public class CentralRectControlEditor :Editor
{
    CentralRectControl centralRect;
    public override void OnInspectorGUI()
    {
        centralRect = target as CentralRectControl;
        base.OnInspectorGUI();
        if (GUILayout.Button("dakai"))
        {
            centralRect.SetRectControl();
        }
    }
}
