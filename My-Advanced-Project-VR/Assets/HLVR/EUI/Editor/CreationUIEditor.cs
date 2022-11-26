using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(CreationUI))]
public class CreationUIEditor : Editor
{
    CreationUI CI;
    public override void OnInspectorGUI()
    {
        CI = target as CreationUI;
        base.OnInspectorGUI();
        GUILayout.BeginHorizontal("s");
        if (GUILayout.Button("Createion")) 
        {
            CI.Creater();
        }
        if (GUILayout.Button("Remove"))
        {
            CI.RemoveAll();
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("s");
        if (GUILayout.Button("Update"))
        {
            CI.Refresh();
        }
        GUILayout.EndHorizontal();
    }
}
