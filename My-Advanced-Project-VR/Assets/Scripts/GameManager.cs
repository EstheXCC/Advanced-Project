using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int enemyCount;
    public static GameManager _instance;
    public GameObject box;
    [HideInInspector]
    public Transform boxT;
    [HideInInspector]
    public GameObject Player;
    [HideInInspector]
    public bool isPetExist = false;
    public GameObject Win;
    public GameObject Fail;
    public bool isKeyEsc = true;
  public   bool isFail = false;
    public GameObject failText;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        GameObject[] enemies =GameObject.FindGameObjectsWithTag("enemy");
        enemyCount = enemies.Length;
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }

    void Update()
    {
        //Win
        if (enemyCount<=0)
        {
           Instantiate(box,boxT.position,Quaternion.identity);
            //AudioManager._instance.Win();
            StartCoroutine("WinWait");
            enemyCount = 100;
        }
        //Fail
        if (Player.GetComponent<Character>().Health<=0)
        {
            isFail = true;
           
            Player.transform.GetChild(0).transform.rotation = Quaternion.Lerp(Player.transform.GetChild(0).transform.rotation, new Quaternion(0.5f, Player.transform.GetChild(0).transform.rotation.y, Player.transform.GetChild(0).transform.rotation.z, Player.transform.GetChild(0).transform.rotation.w),3f*Time.deltaTime);
        }
        if (isFail)
        {
            StartCoroutine("FailWait");
            isFail = false;
        }
    }
    IEnumerator WinWait()
    {
        yield return new WaitForSeconds(5f);
        isKeyEsc = false;
        Win.SetActive(true);
    }
    IEnumerator FailWait()
    {
        yield return new WaitForSeconds(1f);
        Player.GetComponent<Character>().enabled = false;

        //  Player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(2f);
        failText.SetActive(true);
        yield return new WaitForSeconds(5f);
        isKeyEsc = false;
        Fail.SetActive(true);
    }
}
