using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VedioWait : MonoBehaviour
{
   public GameObject GameObject;
    void Start()
    {
        if (PlayerPrefs.HasKey("V"))
        {
            if (PlayerPrefs.GetInt("V") == 1)
            {
                StartCoroutine("wait");
            }
            else
            {
                gameObject.SetActive(false);
                GameObject.SetActive(true);
            }
        }else
        StartCoroutine("wait");
    }

  IEnumerator wait()
    {
        PlayerPrefs.SetInt("V",0);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(14f);
        gameObject.SetActive(false);
        GameObject.SetActive(true);
    }
}
