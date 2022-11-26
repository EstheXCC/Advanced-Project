using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;
    private  AudioSource AudioS;
    public AudioClip hurt;
    public AudioClip clik;
    public AudioClip bubble;
    public AudioClip pick;
    public AudioClip[] enemy;
    public AudioClip usePower;
    public AudioClip win;
    public AudioClip fail;
    public GameObject BGM;
    public bool isMenu = false;
    private void Update()
    {
        if ( !isMenu)
        {
            if (GameManager._instance.isKeyEsc == false)
            {
                BGM.SetActive(false);
            }
        }
        
    }
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        AudioS = GetComponent<AudioSource>();
    }
public void Hurt()
    {
        AudioS.PlayOneShot(hurt);
    }
    public void Clik()
    {
        AudioS.PlayOneShot(clik);
    }
    public void Bubble()
    {
        AudioS.PlayOneShot(bubble);
    }
    public void Pick()
    {
        AudioS.PlayOneShot(pick);
    }
    public void IceBall()
    {
        AudioS.PlayOneShot(enemy[0]);
    }
    public void Keyborad()
    {
        AudioS.PlayOneShot(enemy[1]);
    }
    public void MR()
    {
        AudioS.PlayOneShot(enemy[Random.Range(2,4)]);
    }
    public void UsePower()
    {
        AudioS.PlayOneShot(usePower);

    }
    public void Win()
    {
        AudioS.PlayOneShot(win);

    }
    public void Fail()
    {
        AudioS.PlayOneShot(fail);

    }
}
