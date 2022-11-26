using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 targetPosition;
    public float force=20f;
    public int lessHurt;
    void Start()
    {
        lessHurt = 0;
      
        if (FindObjectOfType<Pet>()!= null)
        {
            lessHurt = 4;
        }
        force = 20f;
        rb = GetComponent<Rigidbody>();
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb.AddForce(((targetPosition+new Vector3(0,0.4f,0)) - transform.position) * force);
        StartCoroutine("destoryWait");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.name=="cannon(Clone)")
            {
                other.GetComponent<Character>().Health -= 5-lessHurt;
                Character._instance.a = 90f;
                AudioManager._instance.Hurt();
                if (GameManager._instance.isPetExist)
                {
                    Pet._instance.hitCount++;
                }
                Destroy(gameObject);
            }else if (gameObject.name == "Water(Clone)")
            {
                other.GetComponent<Character>().Health -= 7-lessHurt;
                Character._instance.a = 120f;
                AudioManager._instance.Hurt();
                if (GameManager._instance.isPetExist)
                {
                    Pet._instance.hitCount++;
                }
                Destroy(gameObject);
            }
            else if (gameObject.name == "Keyboard(Clone)")
            {
                other.GetComponent<Character>().Health -= 10-lessHurt;
                Character._instance.a = 180f;
                AudioManager._instance.Hurt();
                if (GameManager._instance.isPetExist)
                {
                    Pet._instance.hitCount++;
                }
                Destroy(gameObject);
            }


        }
        else if(other.tag == "Bubble")
        {
            Destroy(other.gameObject);
            AudioManager._instance.Bubble();
        }
    }
    private IEnumerator destoryWait()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
   
}
