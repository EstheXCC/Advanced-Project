using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HLVR.Interaction;

namespace HLVR.EUI 
{
    public class EUIManager : MonoBehaviour
    {
        RectTransform[] rects;

        public Vector3LerpStateCentral pos, angle, scale;
        RectControl[] rectControl;

        [Tooltip("单个元素得宽和高")]
        [HideInInspector]
        public float width;
        [HideInInspector]
        public float height;
        [Tooltip("几行几列布局")]
        [HideInInspector]
        public Vector2Int layount;
        [Tooltip("每个元素之间的距离")]
        [HideInInspector]
        public Vector2 offset;
        [HideInInspector]
        Image[] images;

        public EUIManager ()
        {
            width = 0.2f;
            height = 0.2f;
            layount = new Vector2Int(3,3);
            offset = new Vector2(0,0);
            pos.time = 1;
            angle.time = 1;
            scale.time = 1;
        }
        public void Creater()
        {
            images = new Image[Mathf.FloorToInt(layount.x * layount.y)];
            for (int i = 0; i < layount.x * layount.y; i++)
            {
                images[i] = new GameObject("names",typeof(Image)).GetComponent<Image>();
                //images[i] = Instantiate(imagePrefab);
                // images[i] = new Image();
                images[i].transform.parent = this.transform;
                
                if (i < layount.x)
                {
                    images[i].rectTransform.anchoredPosition3D = new Vector3(0, i, 0) + new Vector3(offset.x, offset.y, 0);
                }
                else
                {
                    images[i].rectTransform.anchoredPosition3D = new Vector3(i % layount.x, Mathf.FloorToInt(i / layount.y), 0) + new Vector3(offset.x, offset.y, 0);
                }
                images[i].name = "EUI" + (i + 1).ToString() + "-----" + images[i].rectTransform.anchoredPosition.ToString();
                images[i].rectTransform.sizeDelta = new Vector2(width, height);
                images[i].rectTransform.localScale = Vector3.one;
            }
        }

        public void RemoveAll()
        {
            for (int i = 0; i < layount.x * layount.y; i++)
            {
                if (images[i] != null)
                    DestroyImmediate(images[i].gameObject);
            }
        }

        public void Refresh()
        {
            for (int i = 0; i < layount.x * layount.y; i++)
            {
                if (images[i] != null)
                    images[i].rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
        public void SetRectControl() 
        {
            rectControl = new RectControl[transform.childCount];
            for (int i = 0; i < rectControl.Length; i++)
            {
                rectControl[i] = transform.GetChild(i).GetComponent<RectControl>();
                rectControl[i].pos.m_TarState = pos.m_TarState;
                rectControl[i].pos.time = pos.time;
                rectControl[i].angle.m_TarState = angle.m_TarState;
                rectControl[i].angle.time = angle.time;
                rectControl[i].scale.m_TarState = scale.m_TarState;
                rectControl[i].scale.time = scale.time;
            }
        }
        public void AddIO()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.AddComponent<InteractionObject>();
                Debug.Log("添加到:" + transform.GetChild(i).name+ "完成！ InteractionObject");
            }
        }

        public void RemoveIO()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log("移除从" + transform.GetChild(i).name + "完成！ InteractionObject");
                DestroyImmediate(transform.GetChild(i).gameObject.GetComponent<InteractionObject>());
                DestroyImmediate(transform.GetChild(i).gameObject.GetComponent<AudioSource>());
                DestroyImmediate(transform.GetChild(i).gameObject.GetComponent<BoxCollider>());
              
            }
        }

        public void AddIOAnimation()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.AddComponent<RectControl>();
                Debug.Log("添加到:" + transform.GetChild(i).name + "完成！ RectControl");
            }
        }

        public void RemoveIOAnimation()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log("移除从" + transform.GetChild(i).name + "完成！ RectControl");
                DestroyImmediate(transform.GetChild(i).gameObject.GetComponent<RectControl>());
               
            }
        }


    }
}

