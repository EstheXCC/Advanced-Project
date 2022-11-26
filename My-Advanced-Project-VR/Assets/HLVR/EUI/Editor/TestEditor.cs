using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class TestEditor :Editor
{
    public override void OnInspectorGUI()
    {
        Test tes = target as Test;
        base.OnInspectorGUI();
        if (GUILayout.Button("���Գ���")) 
        {
            tes.testEvent?.Invoke();
        }

        if (GUILayout.Button("���Գ���2"))
        {
            tes.testEvent2?.Invoke();
        }
    }
}
