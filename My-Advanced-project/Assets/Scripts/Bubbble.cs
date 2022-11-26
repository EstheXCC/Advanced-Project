using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubbble : MonoBehaviour
{
    public GameObject Icon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bullet")
        {
            Destroy(other.gameObject);
            AudioManager._instance.Bubble();
            gameObject.SetActive(false);
            Icon.SetActive(false);
        }
    }

}
