using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleRaise : MonoBehaviour
{
    private bool isUp=false;
    private Animator Anim;
    public GameObject Player;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player.GetComponent<Character>().Health <= 0 && !isUp)
        {
           
            StartCoroutine("wait");
            isUp = true;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        Anim.SetBool("up", true);
        yield return new WaitForSeconds(2f);
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        AudioManager._instance.Bubble();
    }
}
