using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class BagManager : MonoBehaviour
{
    public GameObject[] K;
    private int powerIndex;
    public SteamVR_Action_Boolean grabGripAction;
    public SteamVR_Input_Sources inputSource;
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            Color a = new Color(transform.GetChild(i).GetChild(0).GetComponent<Image>().color.r, transform.GetChild(i).GetChild(0).GetComponent<Image>().color.g, transform.GetChild(i).GetChild(0).GetComponent<Image>().color.b, 0.5f);
            transform.GetChild(i).GetChild(0).GetComponent<Image>().color = a;

        }
        K[0].SetActive(true);
        powerIndex = 0;
        transform.GetChild(powerIndex).GetComponent<PowerManager>().enabled = true;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1)|| grabGripAction[inputSource].stateDown)
        {
            K[powerIndex].SetActive(false);
            transform.GetChild(powerIndex).GetComponent<PowerManager>().enabled = false;
            powerIndex++;
            if (powerIndex > 3)
            {
                powerIndex = 0;
            }
            K[powerIndex].SetActive(true);
            transform.GetChild(powerIndex).GetComponent<PowerManager>().enabled = true;
        }
    }
}
