using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreaterCollider : MonoBehaviour
{
    [MenuItem("GameObject/3D ColliderEvent/CubeColliderEvent[创建Cube类型的碰撞盒事件]",false,1)]
    public static void CreaterSelectObjectChildColliderOfCube() 
    {
        Transform[] selects = Selection.transforms;
        for (int i=0;i<selects.Length;i++)
        {
            GameObject obj = new GameObject();
            obj.AddComponent<BoxCollider>();
            obj.transform.parent = selects[i];
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation= Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<BoxCollider>().size = Vector3.one;
            obj.AddComponent<ColliderEvent>();
            obj.name = "ColliderEvent";
        }
    }
}
