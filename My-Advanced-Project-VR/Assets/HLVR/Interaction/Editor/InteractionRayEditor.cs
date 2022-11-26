using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR;
using Valve.VR.InteractionSystem;
namespace HLVR.Interaction 
{
    [CustomEditor(typeof(InteractionRay))]
    public class InteractionRayEditor : Editor
    {
        InteractionRay interactionRay;
        public override void OnInspectorGUI()
        {
            interactionRay = target as InteractionRay;
            base.OnInspectorGUI();
        }

        [MenuItem("HLVR/InteractionRay")]
        public static void CreationInteractionRay()
        {
            Transform[] selectionObject = Selection.transforms;
            for (int i=0;i< selectionObject.Length;i++)
            {
                if (selectionObject[i].GetComponent<Player>() != null)
                    selectionObject[i].gameObject.AddComponent<InteractionRay>(); 
                else Debug.LogError("不允许向非SteamVR Player对象添加此组件");
            }
        }
    }
}

