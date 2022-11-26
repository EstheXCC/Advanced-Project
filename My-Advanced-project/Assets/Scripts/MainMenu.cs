using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int Index;
    public GameObject[] gameObjects;
    private void Awake()
    {
        Cursor.visible = true;
        Index = 1;
        EventCenter.AddListener(EventTypem.Scene1,S1);
        EventCenter.AddListener(EventTypem.Scene2, S2);
        EventCenter.AddListener(EventTypem.Scene3, S3);
        EventCenter.AddListener(EventTypem.Turn, Turn);
        GetComponent<Button>().onClick.AddListener(()=>
        {
            EventCenter.Broadcast(EventTypem.Turn);
        });
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypem.Scene1, S1); 
        EventCenter.RemoveListener(EventTypem.Scene2, S2);
        EventCenter.RemoveListener(EventTypem.Scene3, S3); 
        EventCenter.RemoveListener(EventTypem.Turn, Turn);
    }
    
    private void Turn()
    {
        SceneManager.LoadScene(Index);
    }
  private void S1()
    {
        Index = 1;
       

            gameObjects[0].transform.rotation = new Quaternion(0,0,0,0);
        gameObjects[1].transform.rotation = new Quaternion(0, 180, 0, 0);
        gameObjects[2].transform.rotation = new Quaternion(0, 0, 0, 0);

    }
    private void S2()
    {
        Index = 2;
        gameObjects[0].transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObjects[1].transform.rotation = new Quaternion(0, 180, 0, 0);
        gameObjects[2].transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void S3()
    {
        Index = 3;
        gameObjects[0].transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObjects[1].transform.rotation = new Quaternion(0, 180, 0, 0);
        gameObjects[2].transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            PlayerPrefs.SetInt("V",1);
            PlayerPrefs.Save();
        }
        for (int i=1;i<=3;i++)
        {
            if (Index == i)
            {
                gameObjects[i - 1].transform.Rotate(0,Time.deltaTime*50,0);
        }
        }
      
    }
}
