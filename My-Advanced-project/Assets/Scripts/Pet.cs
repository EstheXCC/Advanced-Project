using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    
   
  
    public GameObject Icon;



    public Transform target;
    public Vector3 offset;
   
    public float backDistance = -1;

   
    public float topDistance = 0;
    public int hitCount ;
    public static Pet _instance;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        hitCount = 0;
        Icon = GameObject.Find("petIcon");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        GameManager._instance.isPetExist = true;
       // dir = transform.position - Target.transform.position;
  
    }
    void LateUpdate()
    {
       
        offset = -target.forward * backDistance + target.up * topDistance;
       
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
       // transform.rotation = Quaternion.LookRotation(target.transform.position);
        transform.LookAt(target);
        if (hitCount>=3)
        {
            Destroy(gameObject);
        }
    }





   

   
    private void OnDestroy()
    {
        GameManager._instance.isPetExist = false;

        Icon.SetActive(false);
    }
}
