using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using HLVR.Interaction;


namespace HLVR.EUI 
{
    [CustomEditor(typeof(EUIManager))]
    public class EUIManagerEditor : Editor
    {
        EUIManager eUIManager;
        SerializedProperty width, height, layount, offset;

        [MenuItem("GameObject/UI/HLVR-EUI/EUIManager")]
        public static void CreationEUIManager()
        {
            GameObject eui = new GameObject();
            eui.AddComponent<EUIManager>();
            eui.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
            eui.name = "EUIManager";
        }

        private void OnEnable()
        {
            width = serializedObject.FindProperty("width");
            height = serializedObject.FindProperty("height");
            layount = serializedObject.FindProperty("layount");
            offset = serializedObject.FindProperty("offset");
            //imagePrefab = serializedObject.FindProperty("imagePrefab");
        }
        public override void OnInspectorGUI()
        {
            GUIStyle topStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
            GUIStyle ButtonStyle = new GUIStyle(EditorStyles.miniButtonLeft);
            ButtonStyle.normal.textColor = Color.green;
            ButtonStyle.hover.textColor = Color.yellow;
            //ButtonStyle.
            topStyle.fontSize = 20;
            topStyle.fontStyle = FontStyle.Bold;
            topStyle.normal.textColor = Color.yellow;
            GUILayout.Label("HLVR-EUI", topStyle);
            eUIManager = target as EUIManager;


            serializedObject.Update();
            EditorGUILayout.PropertyField(width);
            EditorGUILayout.PropertyField(height);
            EditorGUILayout.PropertyField(layount);
            EditorGUILayout.PropertyField(offset);
          //  EditorGUILayout.PropertyField(imagePrefab);
            serializedObject.ApplyModifiedProperties();
            if (GUILayout.Button("CreationUI", ButtonStyle))
            {
                eUIManager.Creater();
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Refresh", ButtonStyle))
            {
                eUIManager.Refresh();
            }
            if (GUILayout.Button("RemoveUI", ButtonStyle))
            {
                eUIManager.RemoveAll();
            }
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add-InteractionObject", ButtonStyle))
            {
                eUIManager.AddIO();
            }
            if (GUILayout.Button("Remove-InteractionObject", ButtonStyle))
            {
                eUIManager.RemoveIO();
            }
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add-IOAnimation", ButtonStyle))
            {
                eUIManager.AddIOAnimation();
            }

            if (GUILayout.Button("Remove-IOAnimation", ButtonStyle))
            {
                eUIManager.RemoveIOAnimation();
            }
            GUILayout.EndVertical();
            base.OnInspectorGUI();
            if (GUILayout.Button("UseDataToRectControl", ButtonStyle))
            {
                eUIManager.SetRectControl();
            }

        }
    }
}

