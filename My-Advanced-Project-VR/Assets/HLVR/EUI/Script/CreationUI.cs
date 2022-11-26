using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreationUI : MonoBehaviour
{
    [Header("����Ԫ�صÿ�͸�")]
    public float width;
    public float height;
    [Header("���м��в���")]
    public Vector2 layount;
    [Header("ÿ��Ԫ��֮��ľ���")]
    public Vector2 offset;
    public GameObject imagePrefab;
    public Image[] images;
    public Transform parent;
    public void Creater()
    {
        images = new Image[Mathf.FloorToInt(layount.x * layount.y)];
        for (int i=0;i<layount.x*layount.y;i++)
        {

           images[i]= Instantiate(imagePrefab).GetComponent<Image>();
           // images[i] = new Image();
           images[i].transform.parent = parent.transform;
            images[i].name = i.ToString();
            if (i < layount.x)
            {
                images[i].rectTransform.anchoredPosition3D = new Vector3(i, 0, 0)+new Vector3(offset.x, offset.y,0);
            }
            else 
            {
                images[i].rectTransform.anchoredPosition3D = new Vector3(i%layount.x,Mathf.FloorToInt(i / layount.y),0)+ new Vector3(offset.x, offset.y, 0);
            }
            images[i].rectTransform.sizeDelta=new Vector2(width, height);
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
            if(images[i]!=null)
            images[i].rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}
