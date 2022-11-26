using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private Animation anim;
    // private  string animName;
    public Animator Anim;
    private float Timer=3f;
    public float t;
    public GameObject bullet;
    public Transform[] weapon;
    public int weaponMouseOrHand;
    Ray ray;
    RaycastHit hit;
    public float health;
    bool isFall=false;
    bool isInvokeDie = false;
    public GameObject HP;
    public bool isHit=false;
    public float tHit;
    public float TimerHit=1f;
    void Start()
    {
        TimerHit = 1f;
          Anim = GetComponent<Animator>();
        t = Timer;
        tHit = TimerHit;
        //int n = Random.Range(0,3);
        //if (n==0)
        //{
        //    animName = "celebration";
        //}else if (n==1)
        //{
        //    animName = "celebration2";
        //}
        //else if (n == 2)
        //{
        //    animName = "celebration3";
        //}
        //anim = GetComponent<Animation>();
        //anim.wrapMode = WrapMode.Loop;
        //anim.Play(animName);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health,0,100);
        HP.transform.localScale = new Vector3(0.1f,0.5f*health/100f,0.01f);
        if (isFall)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        if (health<=0)
        {
            Die();
        }
        if (isHit)
        {
            tHit -= Time.deltaTime;
            if (tHit<0)
            {
                Anim.SetBool("hit",false);
                tHit = TimerHit;
                isHit = false;
            }
        }
    }
    private void Die()
    { 
        if (!isInvokeDie)
        {
            GameManager._instance.enemyCount--;
            if (GameManager._instance.enemyCount<=0)
            {
                GameManager._instance.boxT = transform;
            }
            GameManager._instance.boxT = transform;
            Anim.SetBool("die", true);
            StartCoroutine("dieWait");
            isInvokeDie = true;
        }
         
  
    }
    IEnumerator dieWait()
    {      
        yield return new WaitForSeconds(2f);
        isFall = true;
        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        Physics.SyncTransforms();
        if (other==null)
        {
            Anim.SetBool("attack", false);
        }
        if (other.tag=="Player")
        {
            transform.LookAt(other.transform);
           ray = new Ray(transform.position+new Vector3(0,0.4f, 0),transform.forward);
           // Debug.DrawRay(ray.origin,ray.direction,Color.red);
             //weapon.transform.LookAt(other.transform);
            if (Physics.Raycast(ray,out hit,5,LayerMask.GetMask("Player")))
            {
               // Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.tag=="Player")
                {
                   
                    Anim.SetBool("attack",false);
                    t -= Time.deltaTime;
                    if (t < 0)
                    {
                        if (bullet.name=="cannon")
                        {
                            AudioManager._instance.IceBall();
                        }
                        else if (bullet.name == "Keyboard")
                        {
                            AudioManager._instance.Keyborad();
                        }
                        else if (bullet.name == "Water")
                        {
                            AudioManager._instance.MR();
                        }
                        Anim.SetBool("attack", true);
                        GameObject g = Instantiate(bullet, weapon[weaponMouseOrHand]);
                        //  g.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        t = Timer;
                    }
                }
              
            }
           
        }

    }
}
