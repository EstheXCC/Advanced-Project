using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    public GameObject[] Buttons;
    public Sprite[] sprites;
    public GameObject[] Models;
    void Start()
    {
        
    }

    public void Btn1()
    {
        for (int i=0;i<3;i++)
        {
            if (i!=0)
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                Buttons[i].GetComponent<Image>().sprite = sprites[0];
                Models[i].transform.localScale = new Vector3(0.344f, 0.344f, 0.344f);
            }else
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
                Buttons[i].GetComponent<Image>().sprite = sprites[1];
                Models[i].transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            
        }
    }
    public void Btn2()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != 1)
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                Buttons[i].GetComponent<Image>().sprite = sprites[0];
                Models[i].transform.localScale = new Vector3(0.344f, 0.344f, 0.344f);
            }
            else
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
                Buttons[i].GetComponent<Image>().sprite = sprites[1];
                Models[i].transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }

        }
    }
    public void Btn3()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != 2)
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                Buttons[i].GetComponent<Image>().sprite = sprites[0];
                Models[i].transform.localScale = new Vector3(0.344f, 0.344f, 0.344f);
            }
            else
            {
                Buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
                Buttons[i].GetComponent<Image>().sprite = sprites[1];
                Models[i].transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }

        }
    }
}
