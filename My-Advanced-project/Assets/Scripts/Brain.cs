using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public GameObject Player;
    private void OnEnable()
    {
        StartCoroutine("brainWait");
    }

    private IEnumerator brainWait()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        Player.GetComponent<Character>().speed /= 1.5f;
    }
}
