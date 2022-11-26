using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebWait : MonoBehaviour
{
    public GameObject T1;
    public GameObject Web;
    void Start()
    {
        StartCoroutine("wait");
        Cursor.visible = true;
    }

  IEnumerator wait
        ()
    {
        yield return new WaitForSeconds(3f);
        T1.SetActive(false);
        Web.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;

    }
}
