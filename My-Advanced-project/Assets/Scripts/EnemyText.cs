using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyText : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Text>().text = GameManager._instance.enemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance.enemyCount==100)
        {
            GetComponent<Text>().text = 0.ToString();
        }else
        GetComponent<Text>().text = GameManager._instance.enemyCount.ToString();
    }
}
