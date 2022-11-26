using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoint : MonoBehaviour
{
    public GameObject[] prefabs;

    void Start()
    {
        Instantiate(prefabs[Random.Range(0,4)],transform);
    }

   public void Spawn()
    {
        StartCoroutine("wait");
       
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(20f);
        Instantiate(prefabs[Random.Range(0, 4)], transform);
    }
}
